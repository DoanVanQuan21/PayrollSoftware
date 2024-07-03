using Management.Core.Constants;
using Management.Core.Contracts;
using Management.Core.Models.Devices;
using System.Collections.ObjectModel;

namespace Management.Core.Services
{
    public class DeviceService : IDeviceService
    {
        public DeviceService()
        {
            Devices = new ObservableCollection<Device>();
        }

        public ObservableCollection<Device> Devices { get; set; }

        public void AddDevice<T>(T device) where T : Device
        {
            Devices.Add(device);
        }

        public void DisableDevice(Device device)
        {
            if (device == null)
            {
                return;
            }
            var checkDev = Devices.FirstOrDefault(d => d.ID == device.ID);
            if (checkDev != null)
            {
                return;
            }
            checkDev.IsEnable = false;
        }

        public ObservableCollection<Device> GetDevicesFromType(DeviceType deviceType)
        {
            var devs = Devices.Where(d=>d.DeviceType==deviceType).ToList();
            if(devs.Any()==false)
            {
                return new();
            }
            return new(devs);
        }

        public void RemoveDevice(Device device)
        {
            if (device == null)
            {
                return;
            }
            Devices.Remove(device);
        }

        public void UnMonitorDevice(Device device)
        {
            if (device == null)
            {
                return;
            }
            var checkDev = Devices.FirstOrDefault(d => d.ID == device.ID);
            if (checkDev != null)
            {
                return;
            }
            checkDev.IsMonitor = false;
        }
    }
}