using PayrollSoftware.Core.Models.Devices;
using PayrollSoftware.Devices.Services.Constracts;
using System.Collections.ObjectModel;
using System.Management;

namespace PayrollSoftware.Devices.Services
{
    public class DeviceMonitoring : IDeviceMonitoring
    {
        private ManagementEventWatcher? _arrivedWatcher;
        private ManagementEventWatcher? _removedWatcher;

        public EventHandler<EventArrivedEventArgs> EventDeviceAdded { get; set; }

        public EventHandler<EventArrivedEventArgs> EventDeviceRemoved { get; set; }

        public DeviceMonitoring()
        {
            InitWatcher();
        }

        private void InitWatcher()
        {
            WqlEventQuery arrivalQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
            WqlEventQuery removedQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
            _arrivedWatcher = new ManagementEventWatcher(arrivalQuery);
            _removedWatcher = new ManagementEventWatcher(removedQuery);
            _arrivedWatcher.EventArrived += EventAdded;
            _removedWatcher.EventArrived += EventDeleted;
            _arrivedWatcher.Start();
            _removedWatcher.Start();
        }

        private async void EventDeleted(object sender, EventArrivedEventArgs e)
        {
            //await EventDeleteAsync(sender, e);
            EventDeviceRemoved?.Invoke(sender, e);
        }

        private async void EventAdded(object sender, EventArrivedEventArgs e)
        {
            //await EventAddAsync(sender, e);
            EventDeviceAdded?.Invoke(sender, e);
        }

        public ObservableCollection<HardwareDeviceInfo> GetHardwareDevices()
        {
            ObservableCollection<HardwareDeviceInfo> devices = new();
            ManagementObjectCollection collections;
            var query = @"SELECT * FROM Win32_PnPEntity";
            using (var db = new ManagementObjectSearcher(query))
            {
                collections = db.Get();
                foreach (var item in collections)
                {
                    devices.Add(new HardwareDeviceInfo(item.Properties)
                    {
                    });
                }
            }
            collections.Dispose();
            return devices;
        }

        //private Task EventAddAsync(object sender, EventArrivedEventArgs e)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            var instance = e.NewEvent["TargetInstance"] as ManagementBaseObject;
        //            if (instance == null)
        //            {
        //                return;
        //            }
        //            Application.Current.Dispatcher.Invoke(() =>
        //            {
        //                AddDevice(new HardwareDeviceInfo(instance.Properties));
        //            });
        //            instance?.Dispose();
        //        }
        //        catch (Exception)
        //        {
        //            return;
        //        }
        //    }, tokenSource.Token);
        //}

        //private Task EventDeleteAsync(object sender, EventArrivedEventArgs e)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            var instance = e.NewEvent["TargetInstance"] as ManagementBaseObject;
        //            if (instance == null)
        //            {
        //                return;
        //            }
        //            Application.Current.Dispatcher.Invoke(() =>
        //            {
        //                RemoveDevice(new HardwareDeviceInfo(instance.Properties));
        //            });
        //            instance?.Dispose();
        //        }
        //        catch (Exception)
        //        {
        //            return;
        //        }
        //    }, tokenSource.Token);
        //}

        public void StopWatcher()
        {
            _arrivedWatcher?.Stop();
            _removedWatcher?.Stop();
            //tokenSource?.Cancel();
        }

        public void Dispose()
        {
            StopWatcher();
            _arrivedWatcher?.Dispose();
            _removedWatcher?.Dispose();
        }

        //private void AddDevice(HardwareDeviceInfo device)
        //{
        //    var res = (bool)_deviceManager.Devices?.Any(item => item?.DeviceId == device?.DeviceId);
        //    if (res)
        //    {
        //        return;
        //    }
        //    _deviceManager?.Devices?.Add(device);
        //    ShowMessageInfoDeviceEvent(device, true);
        //}

        //private void RemoveDevice(HardwareDeviceInfo device)
        //{
        //    var first = _deviceManager?.Devices?.FirstOrDefault(item => item?.DeviceId == device?.DeviceId);
        //    if (first == null)
        //    {
        //        return;
        //    }
        //    _deviceManager?.Devices?.Remove(first);
        //    ShowMessageInfoDeviceEvent(first, false);
        //}

        //private void ShowMessageInfoDeviceEvent(HardwareDeviceInfo device, bool isAdded)
        //{
        //    var eventType = isAdded == true ? "Added" : "Removed";
        //    if (device.PnpClass == PnpClass.PORTS)
        //    {
        //        MessageBox.Show($"Device {device.DeviceName} {eventType}");
        //    }
        //}
    }
}