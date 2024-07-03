using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Settings.PCAN;
using PayrollSoftware.PCan.Devices;

namespace PayrollSoftware.PCan.Contracts
{
    public interface IPcanDeviceManager : IDeviceManager<PCanDevice, PCANSetting>
    {
    }
}