using PayrollSoftware.Core.Settings.Videos;
using System.Windows;

namespace PayrollSoftware.Video.Contracts
{
    internal interface ICommonCameraDevice : IBaseCameraDevice
    {
        VideoSetting Config { get; }
        bool IsConnected { get; }
    }
}