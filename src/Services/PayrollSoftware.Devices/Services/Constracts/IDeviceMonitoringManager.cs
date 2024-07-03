using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.Devices;
using System.Collections.ObjectModel;

namespace PayrollSoftware.Devices.Services.Constracts
{
    public interface IDeviceMonitoringManager : IDisposable, ICreateable
    {
        ObservableCollection<HardwareDeviceInfo>? Devices { get; }

        void Update();

        Task Search(string text);
    }
}