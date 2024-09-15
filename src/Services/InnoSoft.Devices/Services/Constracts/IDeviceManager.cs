using InnoSoft.Core.Contracts;
using System.Collections.ObjectModel;

namespace InnoSoft.Devices.Services.Constracts
{
    public interface IDeviceManager<T> : ICreateable, IOpenable, IDisposable, ICloseable
    {
        ObservableCollection<T>? Devices { get; set; }
    }
}