using PayrollSoftware.Core.Mvvms;
using PCANDevice;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PayrollSoftware.PCan.Contracts;

namespace PayrollSoftware.PCan.ViewModels
{
    public class UsbCanSettingViewModel : BaseRegionViewModel
    {
        public ObservableCollection<ushort> CanDevices { get; set; }
        public ObservableCollection<string> Baudrates { get; set; }
        private readonly IPCanDevice _pCanDevice;

        public UsbCanSettingViewModel()
        {
            _pCanDevice = Ioc.Resolve<IPcanDeviceManager>().GetDevice("PCANDevice");
            CanDevices = new();

            Baudrates = new();
        }

        public ICommand LoadingCANDevicesCommand { get; set; }

        public override string Title => "";

        protected override void RegisterCommand()
        {
            LoadingCANDevicesCommand = new DelegateCommand(OnLoadCANDevices);
        }

        private async void OnLoadCANDevices()
        {
            if (CanDevices == null)
            {
                return;
            }
            var canDevices = await GetUsbCANDevices();
            if (canDevices == null)
            {
                return;
            }
            CanDevices.Clear();
            CanDevices.AddRange(canDevices);
        }

        private Task<List<ushort>> GetUsbCANDevices()
        {
            return Task.Factory.StartNew(() =>
            {
                var devs = PCANManager.GetAllAvailable();
                return devs;
            });
        }

    }
}