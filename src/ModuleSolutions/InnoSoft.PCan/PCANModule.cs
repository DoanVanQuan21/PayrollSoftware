using InnoSoft.Core.Context;
using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.WpfPrism;
using InnoSoft.PCan.Views;
using InnoSoft.UI.Geometry;
using Prism.Ioc;
using InnoSoft.PCan.Services;
using InnoSoft.PCan.Contracts;
using InnoSoft.PCan.ViewModels;

namespace InnoSoft.PCan
{
    public class PCANModule : BasePrismModule
    {
        public PCANModule()
        {
        }

        public override string DllName => Core.Constants.DllName.PCANModule;

        public override string ModuleName => "PCan";

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