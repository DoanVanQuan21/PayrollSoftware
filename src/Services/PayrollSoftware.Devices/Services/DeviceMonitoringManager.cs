using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Models.Devices;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Devices.Services.Constracts;
using System.Collections.ObjectModel;
using System.Management;
using System.Windows;

namespace PayrollSoftware.Devices.Services
{
    public class DeviceMonitoringManager : IDeviceMonitoringManager
    {
        private readonly IDeviceMonitoring _deviceMonitoring;
        private CancellationTokenSource? tokenSource;
        private ObservableCollection<HardwareDeviceInfo>? devices = new();
        public ObservableCollection<HardwareDeviceInfo>? Devices { get; private set; }

        public DeviceMonitoringManager()
        {
            _deviceMonitoring = Ioc.Resolve<IDeviceMonitoring>();
            Devices = new ObservableCollection<HardwareDeviceInfo>();
            InitWatcher();
        }

        private void InitWatcher()
        {
            Devices?.Clear();
            devices?.Clear();
            Devices?.AddRange(_deviceMonitoring.GetHardwareDevices());
            devices?.AddRange(Devices);
            tokenSource?.Cancel();
            tokenSource = new CancellationTokenSource();
            _deviceMonitoring.EventDeviceAdded += EventAdded;
            _deviceMonitoring.EventDeviceRemoved += EventDeleted;
        }

        public void Create()
        {
        }

        public void Dispose()
        {
            tokenSource?.Cancel();
            Devices?.Clear();
            devices?.Clear();
            tokenSource?.Dispose();
            Devices = null;
            devices = null;
        }

        public void Update()
        {
        }

        public Task Search(string text)
        {
            return Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SearchByName(text);
                });
            });
        }

        private void SearchByName(string name)
        {
            Devices?.Clear();
            Devices?.AddRange(devices);
            if (string.IsNullOrEmpty(name))
            {
                Devices?.Clear();
                Devices?.AddRange(devices);
                return;
            }
            if (Devices?.Any() == false || devices?.Any() == false)
            {
                return;
            }
            var results = Devices?.Where(item => string.IsNullOrEmpty(item.DeviceName) != true && item.DeviceName.Contains(name)).ToList();
            if (results?.Any() == false)
            {
                Devices?.Clear();
                return;
            }
            var count = results?.Count();
            Devices?.Clear();
            foreach (var result in results)
            {
                Devices?.Add(result);
            }
        }

        private async void EventDeleted(object? sender, EventArrivedEventArgs e)
        {
            await EventDeleteAsync(sender, e);
        }

        private async void EventAdded(object? sender, EventArrivedEventArgs e)
        {
            await EventAddAsync(sender, e);
        }

        private Task EventAddAsync(object sender, EventArrivedEventArgs e)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var instance = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                    if (instance == null)
                    {
                        return;
                    }
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        AddDevice(new HardwareDeviceInfo(instance.Properties));
                    });
                    instance?.Dispose();
                }
                catch (Exception)
                {
                    return;
                }
            }, tokenSource.Token);
        }

        private Task EventDeleteAsync(object sender, EventArrivedEventArgs e)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var instance = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                    if (instance == null)
                    {
                        return;
                    }
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        RemoveDevice(new HardwareDeviceInfo(instance.Properties));
                    });
                    instance?.Dispose();
                }
                catch (Exception)
                {
                    return;
                }
            }, tokenSource.Token);
        }

        private void AddDevice(HardwareDeviceInfo device)
        {
            var res = (bool)Devices?.Any(item => item?.DeviceId == device?.DeviceId);
            if (res)
            {
                return;
            }
            Devices?.Add(device);
            devices?.Add(device);
            ShowMessageInfoDeviceEvent(device, true);
        }

        private void RemoveDevice(HardwareDeviceInfo device)
        {
            var first = Devices?.FirstOrDefault(item => item?.DeviceId == device?.DeviceId);
            if (first == null)
            {
                return;
            }
            Devices?.Remove(first);
            devices?.Remove(first);
            ShowMessageInfoDeviceEvent(first, false);
        }

        private void ShowMessageInfoDeviceEvent(HardwareDeviceInfo device, bool isAdded)
        {
            var eventType = isAdded == true ? "Added" : "Removed";
            if (device.PnpClass == PnpClass.PORTS)
            {
                MessageBox.Show($"Device {device.DeviceName} {eventType}");
            }
        }

    }
}