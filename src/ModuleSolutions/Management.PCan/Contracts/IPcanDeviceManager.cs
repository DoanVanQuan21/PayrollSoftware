using Management.Core.Contracts;
using Management.Core.Settings.PCAN;
using Management.PCan.Devices;

namespace Management.PCan.Contracts
{
    public interface IPcanDeviceManager : IDeviceManager<PCanDevice, PCANSetting>
    {
    }
}