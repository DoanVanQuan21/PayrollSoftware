using DirectShowLib;
using Management.Core.Mvvms;
using Management.Video.Contracts;
using Management.Video.Devices;
using Management.Video.Helpers;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Management.Video.ViewModels
{
    internal class VideoPreviewImageViewModel : BaseRegionViewModel
    {
        private readonly ICameraManager _cameraManager;

        public VideoPreviewImageViewModel()
        {
            _cameraManager = Ioc.Resolve<ICameraManager>();
            CameraDevices = new();
            GetDevices();
        }

        public ICommand AddDeviceCommand { get; set; }
        public ObservableCollection<DsDevice> CameraDevices { get; set; }
        public ICommand DeleteDeviceCommand { get; set; }
        public ObservableCollection<BaseCameraDevice>? Devices => _cameraManager?.Devices;
        public ICommand StartCaptureCommand { get; set; }
        public override string Title => "Camera";

        protected override void RegisterCommand()
        {
            StartCaptureCommand = new DelegateCommand<BaseCameraDevice>(OnStartCapture);
            DeleteDeviceCommand = new DelegateCommand(OnDelete);
            AddDeviceCommand = new DelegateCommand(OnAdd);
        }

        private void GetDevices()
        {
            CameraDevices.AddRange(CameraHelper.GetCameras());
        }

        private void OnAdd()
        {
        }

        private void OnDelete()
        {
        }
        private void OnStartCapture(BaseCameraDevice cameraDevice)
        {
            if (cameraDevice == null)
            {
                return;
            }
            if (cameraDevice.IsConnected)
            {
                cameraDevice.StopCapture();
                return;
            }
            cameraDevice?.StartCapture();
        }
    }
}