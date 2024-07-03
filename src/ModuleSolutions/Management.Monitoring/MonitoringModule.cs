using Management.Core.Constants;
using Management.Core.Context;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.WpfPrism;
using Management.Devices.Services.Constracts;
using Management.Monitoring.ViewModels;
using Management.Monitoring.Views;
using Management.UI.Geometry;
using Prism.Ioc;

namespace Management.Monitoring
{
    public class MonitoringModule : BasePrismModule
    {
        public override string ModuleName => DllName.MonitoringModule;
        private readonly IDeviceMonitoring _deviceManager;
        private readonly IDeviceMonitoring _deviceMonitoring;
        public MonitoringModule() : base()
        {
            _deviceManager = Ioc.Resolve<IDeviceMonitoring>();
            _deviceMonitoring = Ioc.Resolve<IDeviceMonitoring>();
        }

        public override void Dispose()
        {
            _deviceManager.Dispose();
            _deviceMonitoring.Dispose();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            RootContext.MenuSettings.Add(new MenuSetting()
            {
                ViewName = nameof(AllDeviceView),
                Type = typeof(AllDeviceView),
                Geometry = GeometryString.DeviceManagerGeometry,
                Label = "Device Manager"
            });
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<AllDeivceViewModel>();
        }

        public override void Init()
        {
            //TODO
        }

        public override void Register()
        {
            //TODO
        }
    }
}