using PayrollSoftware.Comport.Devices;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Settings.Comports;

namespace PayrollSoftware.Comport.Contracts
{
    internal interface IComportManager : IDeviceManager<ComportDevice, SerialPortSetting>, IDisposable
    {

    }
}