using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using Prism.Events;
using Prism.Ioc;

namespace PayrollSoftware.Core.WpfPrism
{
    public abstract class BasePrismModule : ICustomModule
    {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IAppManager _settingManager;
        protected List<Action> DisposeActions = new();
        private readonly ICustomModuleManager _customModuleManager;

        public BasePrismModule()
        {
            _customModuleManager = Ioc.Resolve<ICustomModuleManager>();
            _eventAggregator = Ioc.Resolve<IEventAggregator>();
            _settingManager = Ioc.Resolve<IAppManager>();
            _customModuleManager.CustomModules.Add(this);
        }

        public abstract string DllName { get; }
        public BootSetting? BootSetting { get; }

        public abstract string ModuleName { get; }

        public abstract void Dispose();

        public abstract void Init();

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void Register();

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

    }
}