using Management.Core.Contracts;
using System.Collections.ObjectModel;

namespace Management.Devices.Services.Constracts
{
    public interface IDeviceManager<T> : ICreateable, IOpenable, IDisposable, ICloseable
    {
        ObservableCollection<T>? Devices { get; set; }
    }
}