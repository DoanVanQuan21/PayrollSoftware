using PayrollSoftware.Comport.Devices;
using PayrollSoftware.Comport.Contracts;
using PayrollSoftware.Comport.Devices;
using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Settings.Comports;
using System.Collections.ObjectModel;
using System.Windows;

namespace PayrollSoftware.Comport.Services
{
    internal class ComportManager : IComportManager
    {
        protected readonly IAppManager _appManager;
        protected readonly IDeviceService _deviceService;
        public ComportManager()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            _deviceService = Ioc.Resolve<IDeviceService>();
        }

        public virtual ObservableCollection<ComportDevice>? Devices { get; set; } = new ObservableCollection<ComportDevice>();

        public async Task<bool> AddDevice(SerialPortSetting config)
        {
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                _appManager?.BootSetting?.SerialPortSettings.Add(config);
                CreateComportDeviceWithType(config);
            });
            return true;
        }

        public void Create(params object[] objs)
        {
            if (objs[0] is not IList<SerialPortSetting> configs)
            {
                return;
            }
            foreach (var config in configs)
            {
                CreateComportDeviceWithType(config);
            }
        }

        public void Dispose()
        {
            foreach (var dev in Devices)
            {
                dev?.Dispose();
            }
            Devices.Clear();
        }

        public virtual ComportDevice? GetDevice(string name)
        {
            return Devices?.FirstOrDefault(item => item.DevName == name);
        }

        public Task<bool> RemoveDevice(ComportDevice device)
        {
            return Task.Factory.StartNew(() =>
            {
                return Application.Current.Dispatcher.Invoke(() =>
                {
                    var deviceExist = Devices?.FirstOrDefault(d => d.ID == device.ID);
                    if (deviceExist == null)
                    {
                        return false;
                    }
                    var config = _appManager.BootSetting.SerialPortSettings.FirstOrDefault(c => c.ID == device.Config.ID);
                    if (config == null)
                    {
                        return false;
                    }
                    _appManager.BootSetting.SerialPortSettings.Remove(config);
                    _deviceService.RemoveDevice(device);
                    return Devices.Remove(deviceExist);
                });
            });
        }

        private void CreateComportDeviceWithType(SerialPortSetting config)
        {
            switch (config.DeviceType)
            {
                case DeviceType.TextCommand:
                    var textDevice = new TextCommandDevice(config);
                    Devices?.Add(textDevice);
                    _deviceService.AddDevice(textDevice);
                    break;

                case DeviceType.ByteCommand:
                    var byteCommand = new ByteCommandDevice(config);
                    Devices?.Add(byteCommand);
                    _deviceService.AddDevice(byteCommand);
                    break;

                default:
                    break;
            }
        }
    }
}