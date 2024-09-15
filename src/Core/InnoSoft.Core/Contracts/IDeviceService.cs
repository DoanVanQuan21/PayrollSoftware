using InnoSoft.Core.Constants;
using InnoSoft.Core.Models.Devices;
using System.Collections.ObjectModel;

namespace InnoSoft.Core.Contracts
{
    public interface IDeviceService
    {
        ObservableCollection<Device> Devices { get; set; }

        void AddDevice<T>(T device) where T : Device;

        void RemoveDevice(Device device);

        void UnMonitorDevice(Device device);

        void DisableDevice(Device device);
        ObservableCollection<Device> GetDevicesFromType(DeviceType deviceType);
    }
}