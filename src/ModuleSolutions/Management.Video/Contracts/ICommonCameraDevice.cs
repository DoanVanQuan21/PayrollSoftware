using Management.Core.Settings.Videos;
using System.Windows;

namespace Management.Video.Contracts
{
    internal interface ICommonCameraDevice : IBaseCameraDevice
    {
        VideoSetting Config { get; }
        bool IsConnected { get; }
    }
}