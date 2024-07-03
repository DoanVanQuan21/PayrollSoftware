using Management.Core.Contracts;
using Management.Core.Settings.Videos;
using Management.Video.Devices;

namespace Management.Video.Contracts
{
    internal interface ICameraManager : IDeviceManager<BaseCameraDevice, VideoSetting>, IDisposable
    {
    }
}