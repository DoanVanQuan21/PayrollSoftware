using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.UI.Geometry;
using Prism.Ioc;
using PayrollSoftware.PCan.Contracts;
using PayrollSoftware.PCan.ViewModels;
using PayrollSoftware.PCan.Services;
using PayrollSoftware.PCan.Views;

namespace PayrollSoftware.PCan
{
    public class PCANModule : BasePrismModule
    {
        public PCANModule()
        {
        }

        public override string ModuleName => DllName.PCANModule;

        public override void Dispose()
        {
        }

        public override void Init()
        {
            InitMenu();
            var enabledDevices = _settingManager?.BootSetting?.PCANSettings.Where(p => p.IsEnabled).ToList();
            if (enabledDevices?.Any() == false)
            {
                return;
            }
            var manager = Ioc.Resolve<IPcanDeviceManager>();
            manager.Create(enabledDevices);
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            Init();
        }

        public override void Register()
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<UsbCanSettingViewModel>();
            containerRegistry.RegisterSingleton<IPcanDeviceManager, PCanDeviceManager>();
        }

        private void InitMenu()
        {
            var menus = new List<MenuSetting>() {
                new MenuSetting()
                {
                    Type = typeof(UsbCanSettingView),
                    ViewName = nameof(UsbCanSettingView),
                    Label = "PCAN Setting",
                    Geometry = GeometryString.PCANGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menus);
        }
    }
}