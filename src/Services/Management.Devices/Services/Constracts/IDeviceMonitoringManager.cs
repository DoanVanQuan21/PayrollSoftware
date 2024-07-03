using Management.Core.Contracts;
using Management.Core.Models.Devices;
using System.Collections.ObjectModel;

namespace Management.Devices.Services.Constracts
{
    public interface IDeviceMonitoringManager : IDisposable, ICreateable
    {
        ObservableCollection<HardwareDeviceInfo>? Devices { get; }

        void Update();

        Task Search(string text);
    }
}