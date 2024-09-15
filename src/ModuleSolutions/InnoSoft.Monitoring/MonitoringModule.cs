using InnoSoft.Core.Context;
using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.WpfPrism;
using InnoSoft.Monitoring.Views;
using InnoSoft.UI.Geometry;
using Prism.Ioc;
using InnoSoft.Monitoring.ViewModels;
using InnoSoft.Devices.Services.Constracts;

namespace InnoSoft.Monitoring
{
    public class MonitoringModule : BasePrismModule
    {
        public override string DllName => Core.Constants.DllName.MonitoringModule;

        public override string ModuleName => "Monitoring";

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