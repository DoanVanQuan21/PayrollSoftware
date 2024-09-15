using InnoSoft.Core.Contracts;
using InnoSoft.Core.Settings.PCAN;
using InnoSoft.PCan.Devices;

namespace InnoSoft.PCan.Contracts
{
    public interface IPcanDeviceManager : IDeviceManager<PCanDevice, PCANSetting>
    {
    }
}