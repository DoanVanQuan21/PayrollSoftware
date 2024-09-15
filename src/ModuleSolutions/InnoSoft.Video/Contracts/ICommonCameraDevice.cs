using InnoSoft.Core.Settings.Videos;
using System.Windows;

namespace InnoSoft.Video.Contracts
{
    internal interface ICommonCameraDevice : IBaseCameraDevice
    {
        VideoSetting Config { get; }
        bool IsConnected { get; }
    }
}