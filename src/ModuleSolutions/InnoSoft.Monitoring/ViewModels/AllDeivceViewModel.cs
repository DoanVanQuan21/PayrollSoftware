using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models.Devices;
using InnoSoft.Core.Mvvms;
using InnoSoft.Devices.Services.Constracts;
using System.Collections.ObjectModel;

namespace InnoSoft.Monitoring.ViewModels
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