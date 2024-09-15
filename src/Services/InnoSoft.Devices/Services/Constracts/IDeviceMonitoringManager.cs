using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models.Devices;
using System.Collections.ObjectModel;

namespace InnoSoft.Devices.Services.Constracts
{
    public interface IDeviceMonitoringManager : IDisposable, ICreateable
    {
        ObservableCollection<HardwareDeviceInfo>? Devices { get; }

        void Update();

        Task Search(string text);
    }
}