using PayrollSoftware.Core.Contracts;
using System.Collections.ObjectModel;

namespace PayrollSoftware.Devices.Services.Constracts
{
    public interface IDeviceManager<T> : ICreateable, IOpenable, IDisposable, ICloseable
    {
        ObservableCollection<T>? Devices { get; set; }
    }
}