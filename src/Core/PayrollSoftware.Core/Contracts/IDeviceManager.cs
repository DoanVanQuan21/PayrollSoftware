using System.Collections.ObjectModel;

namespace PayrollSoftware.Core.Contracts
{
    public interface IDeviceManager<TDevice, TConfig>
    {
        ObservableCollection<TDevice>? Devices { get; set; }

        void Create(params object[] objs);
        TDevice? GetDevice(string name);
        Task<bool> RemoveDevice(TDevice device);
        Task<bool> AddDevice(TConfig config);
    }
}