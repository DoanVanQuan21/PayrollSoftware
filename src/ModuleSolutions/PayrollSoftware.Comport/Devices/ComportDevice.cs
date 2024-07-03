using PayrollSoftware.Core.Helpers;
using PayrollSoftware.Core.Models.Devices;
using PayrollSoftware.Core.Settings.Comports;
using System.IO.Ports;

namespace PayrollSoftware.Comport.Devices
{
    public abstract class ComportDevice : IOBaseDevice
    {
        private SerialPortSetting currentConfig;
        protected SerialPort? _comport;
        protected SerialPortSetting _config;

        public ComportDevice()
        {
            Config = new();
        }

        public ComportDevice(SerialPortSetting config)
        {
            Config = config;
            DevName = Config.DevName;
            DeviceType = Config.DeviceType;
            ID = Config.ID;
            Task.Factory.StartNew(GetRawDatas, _tokenSource.Token);
        }

        public SerialPortSetting Config { get => _config; set => SetProperty(ref _config, value); }

        public static List<string> GetPorts()
        {
            return SerialPort.GetPortNames().ToList();
        }

        public override void CleanUp()
        {
        }

        public override void Close()
        {
            if (_comport == null)
            {
                IsConnected = false;
                return;
            }
            _comport.Close();
            IsConnected = _comport.IsOpen;
        }

        public override void Create()
        {
        }

        public override void Dispose()
        {
            Close();
            _tokenSource?.Cancel();
        }

        public override void Init()
        {
            Open();
        }

        private bool IsConfigChanged()
        {
            if (currentConfig == null || Config == null)
            {
                return false;
            }
            return currentConfig.EqualTo(Config);
        }

        private void RefreshComport()
        {
            if (IsConfigChanged())
            {
                return;
            }
            _comport?.Close();
            _comport?.Dispose();
            _comport = new(Config.Port, Config.Baudrate);
            currentConfig = Config.Clone();
        }

        public override void Open()
        {
            try
            {
                RefreshComport();
                if (_comport == null)
                {
                    IsConnected = false;
                }
                _comport.Open();
                IsConnected = _comport.IsOpen;
            }
            catch (Exception)
            {
                IsConnected = false;
            }
        }

        protected abstract void GetRawData();

        private async Task GetRawDatas()
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                if (_comport == null || !_comport.IsOpen)
                {
                    await Task.Delay(20);
                    continue;
                }
                GetRawData();
            }
        }
    }
}