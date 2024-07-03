using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.Devices;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Devices.Services.Constracts;
using System.Collections.ObjectModel;

namespace PayrollSoftware.Monitoring.ViewModels
{
    internal class AllDeivceViewModel : BaseRegionViewModel
    {
        private readonly IDeviceService _deviceService;
        private int totalDevice;

        public AllDeivceViewModel() : base()
        {
            _deviceService = Ioc.Resolve<IDeviceService>();
        }

        public ObservableCollection<Device> Devices => _deviceService.Devices;
        public override string Title => "All Device";

        public int TotalDevice
        { get => totalDevice; set { SetProperty(ref totalDevice, value); } }
    }
}