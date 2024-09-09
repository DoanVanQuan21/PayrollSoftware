using Emgu.CV;
using PayrollSoftware.Core.Settings.Videos;
using PayrollSoftware.Video.Contracts;
using PayrollSoftware.Video.Helpers;
using PayrollSoftware.Video.Models;
using System.Diagnostics;

namespace PayrollSoftware.Video.Devices
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