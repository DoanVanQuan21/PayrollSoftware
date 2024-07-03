using HandyControl.Tools.Extension;
using PayrollSoftware.Comport.Views.Dialogs;
using PayrollSoftware.Core.Models.Common;
using PayrollSoftware.Core.Models.Devices.Sessions;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Services;
using PayrollSoftware.Core.Settings.Comports;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PayrollSoftware.Comport.Contracts;
using PayrollSoftware.Comport.Devices;

namespace PayrollSoftware.Comport.ViewModels
{
    internal class ComportSettingViewModel : BaseRegionViewModel
    {
        private const int MAX_BYTE = 64;
        private readonly IComportManager _comportManager;
        private int byteNumber;
        private ComportDevice currentDevice;
        private string response;
        private TextSession textSession;

        public ComportSettingViewModel()
        {
            _comportManager = Ioc.Resolve<IComportManager>();
            InitBaudrates();
            InitByteNumbers().GetAwaiter();
            PortNames = new();
            CommandValues = new();
            GetPortName();
            CurrentDevice = _comportManager.Devices?.FirstOrDefault();
            ByteNumber = 8;
            TextSession = new();
            ByteSession = new();
        }

        public ICommand AddDeviceCommand { get; set; }

        public ObservableCollection<int> Baudrates { get; set; }

        public int ByteNumber
        { get => byteNumber; set { SetProperty(ref byteNumber, value); CheckCommandValues().GetAwaiter(); } }

        public ObservableCollection<int> ByteNumbers { get; set; }
        public ByteSession ByteSession { get; set; }
        public ObservableCollection<KeyValue> CommandValues { get; set; }
        public ObservableCollection<ComportDevice>? ComportDevices => _comportManager.Devices;
        public ICommand ConnectComportDeviceCommand { get; set; }
        public ComportDevice CurrentDevice { get => currentDevice; set => SetProperty(ref currentDevice, value); }
        public ICommand DeleteDeviceCommand { get; set; }
        public ObservableCollection<string> PortNames { get; set; }
        public string Response { get => response; set => SetProperty(ref response, value); }
        public ICommand SendCommand { get; set; }
        public TextSession TextSession { get => textSession; set => SetProperty(ref textSession, value); }
        public override string Title => "Comport setting";

        public Task GetPortName()
        {
            return Task.Factory.StartNew(() =>
            {
                PortNames.Clear();
                PortNames.AddRange(ComportDevice.GetPorts());
            });
        }

        protected override void RegisterCommand()
        {
            DeleteDeviceCommand = new DelegateCommand<ComportDevice>(OnDeleteSerialPort);
            AddDeviceCommand = new DelegateCommand(OnAdd);
            SendCommand = new DelegateCommand(OnSend);
            ConnectComportDeviceCommand = new DelegateCommand(OnConnect);
        }

        private Task AddCommandValues(int endIndex)
        {
            return Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < endIndex; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CommandValues.Add(new()
                        {
                            Key = string.Empty,
                            Value = "00"
                        });
                    });
                }
            });
        }

        private async void AddComportDevice(SerialPortSetting setting)
        {
            if (setting == null)
            {
                await CustomNotification.Warning($"Không thể thêm thêm thiết bị {setting.DevName}");
                return;
            }
            var serial = BootSetting.SerialPortSettings.FirstOrDefault(s => s.DevName == setting.DevName);
            if (serial != null)
            {
                await CustomNotification.Warning($"Thiết bị {setting.DevName} đã tồn tại ");
                return;
            }
            var isCreated = await _comportManager.AddDevice(setting);
            if (!isCreated)
            {
                await CustomNotification.Warning($"Loại thiết bị {setting.DeviceType} bạn chọn không hợp lệ");
                return;
            }
            CloseDialog();
            await CustomNotification.Success($"Thêm thiết bị {setting.DevName} thành công!.");
        }

        private async Task CheckCommandValues()
        {
            if (ByteNumber > CommandValues.Count)
            {
                await AddCommandValues(ByteNumber - CommandValues.Count);
                return;
            }
            if (ByteNumber == CommandValues.Count)
            {
                return;
            }
            await RemoveCommandValues(CommandValues.Count, ByteNumber);
        }

        private void InitBaudrates()
        {
            Baudrates = new() {
                110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000
            };
        }

        private async Task InitByteNumbers()
        {
            ByteNumbers = new();
            for (int i = 1; i <= MAX_BYTE; i++)
            {
                ByteNumbers.Add(i);
                await Task.Delay(10);
            }
        }

        private void OnAdd()
        {
            var addDialog = new AddSerialPortDeviceView();
            addDialog.SetAddAcction(AddComportDevice);
            ShowDialog(addDialog);
        }

        private void OnConnect()
        {
            if (CurrentDevice == null)
            {
                return;
            }
            if (CurrentDevice.IsConnected)
            {
                CurrentDevice.Close();
                return;
            }
            CurrentDevice.Open();
        }

        private async void OnDeleteSerialPort(ComportDevice device)
        {
            var isDeleted = await _comportManager.RemoveDevice(device);
            if (!isDeleted)
            {
                await CustomNotification.Warning($"Không thể xóa thiết bị {device.DevName}!.");
                return;
            }
            await CustomNotification.Success($"Xóa thiết bị {device.DevName} thành công!.");
        }

        private async void OnSend()
        {
            switch (CurrentDevice.DeviceType)
            {
                case DeviceType.TextCommand:
                    var textSession = await CurrentDevice.SendAndWait(TextSession);
                    if (textSession == null)
                    {
                        return;
                    }
                    if (textSession.Result == ResultType.NG)
                    {
                        UpdateData(textSession.Result.ToString());
                        return;
                    }
                    var t = textSession as TextSession;
                    UpdateData(t.Response);
                    return;

                case DeviceType.ByteCommand:
                    var session = await CurrentDevice.SendAndWait(TextSession);
                    if (session.Result == ResultType.NG)
                    {
                        UpdateData(session.Result.ToString());
                        return;
                    }
                    var byteSession = session as ByteSession;
                    UpdateData(string.Join("-", byteSession?.ResponseBytes));
                    return;

                default:
                    break;
            }
        }

        private Task RemoveCommandValues(int startIndex, int endIndex)
        {
            return Task.Factory.StartNew(() =>
            {
                for (int i = startIndex - 1; i >= endIndex; i--)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CommandValues.RemoveAt(i);
                    });
                }
            });
        }

        private void UpdateData(string response)
        {
            Response += $"\n : {response}";
        }
    }
}