using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.Devices.Services.Constracts;
using PayrollSoftware.Monitoring.ViewModels;
using PayrollSoftware.Monitoring.Views;
using PayrollSoftware.UI.Geometry;
using Prism.Ioc;

namespace PayrollSoftware.Monitoring
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