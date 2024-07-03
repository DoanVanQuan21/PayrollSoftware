using Management.Core.Contracts;
using Management.Core.Mvvms;
using System.Collections.ObjectModel;

namespace Management.Core.Services.Manager
{
    public abstract class DeviceManager<TDevice, TConfig> : IDeviceManager<TDevice, TConfig>
    {
        protected readonly IAppManager _appManager;

        public DeviceManager()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public ObservableCollection<TDevice>? Devices { get; set; }

        public Task<bool> AddDevice(TConfig config)
        {
            throw new NotImplementedException();
        }

        public abstract void Create(params object[] objs);

        public abstract TDevice? GetDevice(string name);

        public virtual Task<bool> RemoveDevice(TDevice device)
        {
            throw new NotImplementedException();
        }
    }
}