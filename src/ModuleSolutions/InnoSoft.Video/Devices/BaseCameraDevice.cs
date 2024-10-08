﻿using InnoSoft.Core.Models.Devices;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Settings.Videos;
using InnoSoft.Video.Services;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Windows;
using InnoSoft.Video.Contracts;
using InnoSoft.Video.Models;

namespace InnoSoft.Video.Devices
{
    internal abstract class BaseCameraDevice : Device, IBaseCameraDevice
    {
        protected readonly IImageProcess _imageProcess;
        protected ConcurrentQueue<ImageCV> rawImages;
        protected CancellationTokenSource tokenSource;
        private VideoSetting _config;

        public BaseCameraDevice(VideoSetting config)
        {
            _imageProcess = Ioc.Resolve<IImageProcess>();
            Config = config;
            DevName = Config.DevName;
            DeviceType = Config.DeviceType;
            rawImages = new();
            tokenSource = new CancellationTokenSource();
            ImageRender = new ImageRender(config.PreviewSize.Width, config.PreviewSize.Height);
            Image = ImageRender.GetImageControl();
        }

        public VideoSetting Config { get => _config; set => SetProperty(ref _config, value); }
        public UIElement Image { get; protected set; }
        public IImageRender ImageRender { get; set; }

        public override void Dispose()
        {
            tokenSource?.Cancel();
            tokenSource?.Dispose();
            rawImages?.Clear();
        }

        public virtual void StartCapture()
        {
            tokenSource = new();
            IsConnected = true;
            Task.Factory.StartNew(CaptureImageFromCamera, tokenSource.Token);
            Task.Factory.StartNew(ProcessImage, tokenSource.Token);
        }

        public virtual void StopCapture()
        {
            IsConnected = false;
            tokenSource?.Cancel();
            tokenSource?.Dispose();
        }

        protected abstract Task CaptureImageFromCamera();

        protected abstract Task ProcessRawImage(ImageCV image);

        private async Task ProcessImage()
        {
            while (!tokenSource.IsCancellationRequested)
            {
                try
                {
                    if (rawImages == null || rawImages?.Any() == false)
                    {
                        continue;
                    }
                    var isDequeuedSuccess = rawImages.TryDequeue(out var image);
                    if (!isDequeuedSuccess || image == null)
                    {
                        continue;
                    }
                    await ProcessRawImage(image);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    await Task.Delay(2);
                }
            }
        }
    }
}