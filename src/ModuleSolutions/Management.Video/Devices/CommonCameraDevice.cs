using Emgu.CV;
using Emgu.CV.Structure;
using Management.Core.Settings.Videos;
using Management.Video.Contracts;
using Management.Video.Helpers;
using Management.Video.Models;
using Management.Video.Services;
using System.Diagnostics;
using System.Drawing;
using System.Windows;

namespace Management.Video.Devices
{
    internal class CommonCameraDevice : BaseCameraDevice, ICommonCameraDevice
    {
        private VideoCapture videoCapture;

        public CommonCameraDevice(VideoSetting config) : base(config)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            videoCapture?.Stop();
            videoCapture?.Dispose();
            videoCapture = null;
        }

        public override void StartCapture()
        {
            if (videoCapture != null)
            {
                videoCapture.Stop();
                videoCapture.Dispose();
                videoCapture = null;
            }
            base.StartCapture();
            var cameraIndex = CameraHelper.GetCameraIndex(Config.HardwareName);
            videoCapture = new VideoCapture(cameraIndex);
            videoCapture.Start();
        }

        public override void StopCapture()
        {
            if (videoCapture == null)
            {
                return;
            }
            base.StopCapture();
            videoCapture?.Stop();
            videoCapture?.Dispose();
            videoCapture = null;
            ClearRawData();
        }

        protected override async Task CaptureImageFromCamera()
        {
            while (!tokenSource.IsCancellationRequested)
            {
                try
                {
                    if (videoCapture == null)
                    {
                        continue;
                    }
                    var image = new ImageCV(Config.PreviewSize.Width, Config.PreviewSize.Height);
                    var isReceived = videoCapture.Retrieve(image);
                    if (!isReceived)
                    {
                        continue;
                    }
                    rawImages.Enqueue(image);
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

        protected override async Task ProcessRawImage(ImageCV image)
        {
            try
            {
                await _imageProcess.DectectObject(image);
                await ImageRender.Render(image);
                image.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ClearRawData()
        {
            while (rawImages?.Count > 0)
            {
                rawImages.TryDequeue(out var image);
                image?.Dispose();
            }
        }
    }
}