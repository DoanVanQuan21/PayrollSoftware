using InnoSoft.Core.Settings.Videos;
using InnoSoft.Core.Constants;
using System.Collections.ObjectModel;
using InnoSoft.Video.Contracts;
using InnoSoft.Video.Devices;

namespace InnoSoft.Video.Managers
{
    internal class CameraManager : ICameraManager
    {
        public ObservableCollection<BaseCameraDevice>? Devices { get; set; } = new();

        public Task<bool> AddDevice(VideoSetting config)
        {
            throw new NotImplementedException();
        }

        public void Create(params object[] objs)
        {
            if (objs[0] is not IList<VideoSetting> configs)
            {
                return;
            }
            foreach (var config in configs)
            {
                CreateCameraDeviceWithType(config);
            }
        }

        private void CreateCameraDeviceWithType(VideoSetting config)
        {
            switch (config.DeviceType)
            {
                case DeviceType.VIDEO:
                    Devices?.Add(new CommonCameraDevice(config));
                    return;
            }
        }

        public BaseCameraDevice? GetDevice(string name)
        {
            return Devices?.FirstOrDefault(c => c.DevName == name);
        }

        public Task<bool> RemoveDevice(BaseCameraDevice device)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            foreach (var dev in Devices)
            {
                dev?.Dispose();
            }
        }
    }
}