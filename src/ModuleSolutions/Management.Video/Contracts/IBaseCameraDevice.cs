using System.Windows;

namespace Management.Video.Contracts
{
    internal interface IBaseCameraDevice : IDisposable
    {
        void StartCapture();

        void StopCapture();

        UIElement Image { get; }
        IImageRender ImageRender { get; set; }
    }
}