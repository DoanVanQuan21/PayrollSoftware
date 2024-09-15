using InnoSoft.Core.Contracts;
using InnoSoft.Core.Settings.Videos;
using InnoSoft.Video.Devices;

namespace InnoSoft.Video.Contracts
{
    internal interface ICameraManager : IDeviceManager<BaseCameraDevice, VideoSetting>, IDisposable
    {
    }
}