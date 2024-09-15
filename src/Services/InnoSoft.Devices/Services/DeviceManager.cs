using InnoSoft.Devices.Services.Constracts;
using System.Collections.ObjectModel;

namespace InnoSoft.Devices.Services
{
    public class DeviceManager<T> : IDeviceManager<T>
    {
        public ObservableCollection<T>? Devices { get; set; }

        public void Close()
        {
        }

        public void Create()
        {
        }

        public void Dispose()
        {
        }

        public void Open()
        {
        }
    }
}