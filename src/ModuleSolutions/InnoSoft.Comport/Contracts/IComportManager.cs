using InnoSoft.Core.Contracts;
using InnoSoft.Core.Settings.Comports;
using InnoSoft.Comport.Devices;

namespace InnoSoft.Comport.Contracts
{
    internal interface IComportManager : IDeviceManager<ComportDevice, SerialPortSetting>, IDisposable
    {

    }
}