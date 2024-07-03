﻿using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Models;
using Management.Core.Mvvms;
using Prism.Events;
using Prism.Ioc;

namespace Management.Core.WpfPrism
{
    public abstract class BasePrismModule : ICustomModule
    {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IAppManager _settingManager;
        protected List<Action> DisposeActions = new();

        public BasePrismModule()
        {
            _eventAggregator = Ioc.Resolve<IEventAggregator>();
            _settingManager = Ioc.Resolve<IAppManager>();
            _eventAggregator.GetEvent<ExitApplicationEvent>().Subscribe(OnExit);
        }

        public abstract string ModuleName { get; }
        public BootSetting? BootSetting { get; }

        public abstract void Dispose();

        public abstract void Init();

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void Register();

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        private void OnExit()
        {
            Dispose();
            _eventAggregator.GetEvent<ExitApplicationEvent>().Unsubscribe(OnExit);
        }
    }
}