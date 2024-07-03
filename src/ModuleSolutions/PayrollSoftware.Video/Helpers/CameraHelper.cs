using DirectShowLib;
using System.Collections.ObjectModel;

namespace PayrollSoftware.Video.Helpers
{
    internal static class CameraHelper
    {
        public static ObservableCollection<DsDevice> GetCameras()
        {
            var cameraDevices = new ObservableCollection<DsDevice>();
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var device in devices)
            {
                cameraDevices.Add(device);
            }
            return cameraDevices;
        }

        public static int GetCameraIndex(string deviceName)
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            return devices.ToList().FindIndex(d => d.Name == deviceName);
        }
    }
}