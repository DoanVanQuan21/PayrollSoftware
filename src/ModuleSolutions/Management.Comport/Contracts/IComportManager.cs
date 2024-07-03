using Management.Comport.Devices;
using Management.Core.Contracts;
using Management.Core.Settings.Comports;

namespace Management.Comport.Contracts
{
    internal interface IComportManager : IDeviceManager<ComportDevice, SerialPortSetting>, IDisposable
    {

    }
}