using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Settings.Videos;
using PayrollSoftware.Video.Devices;

namespace PayrollSoftware.Video.Contracts
{
    internal interface ICameraManager : IDeviceManager<BaseCameraDevice, VideoSetting>, IDisposable
    {
    }
}