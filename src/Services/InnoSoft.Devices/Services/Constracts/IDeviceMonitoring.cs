using System.Collections.ObjectModel;
using System.Management;
using InnoSoft.Core.Models.Devices;
namespace InnoSoft.Devices.Services.Constracts
{
    public interface IDeviceMonitoring
    {
        ObservableCollection<HardwareDeviceInfo> GetHardwareDevices();
        EventHandler<EventArrivedEventArgs> EventDeviceAdded { get; set; }
        EventHandler<EventArrivedEventArgs> EventDeviceRemoved { get; set; }
        void StopWatcher();
        void Dispose();
    }
}