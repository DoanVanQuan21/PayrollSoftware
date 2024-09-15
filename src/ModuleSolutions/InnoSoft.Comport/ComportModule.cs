using InnoSoft.Comport.Views;
using InnoSoft.Core.Context;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Settings.Comports;
using InnoSoft.Core.WpfPrism;
using InnoSoft.UI.Geometry;
using Prism.Ioc;
using InnoSoft.Comport.Contracts;
using InnoSoft.Comport.Services;

namespace InnoSoft.Comport
{
    public class ComportModule : BasePrismModule
    {
        private IDeviceService deviceService;
        public override string DllName => Core.Constants.DllName.ComportModule;

        public override string ModuleName => "Comport";

        public override void Dispose()
        {
            foreach (var action in DisposeActions)
            {
                action?.Invoke();
            }
        }

        public override void Init()
        {
            InitMenu();
            var enabledDevices = _settingManager?.BootSetting?.SerialPortSettings.Where(item => item.IsEnabled).ToList();
            if (enabledDevices?.Any() == false)
            {
                return;
            }
            InitDevices(enabledDevices);
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            Init();
        }

        public override void Register()
        {
            //TODO
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IComportManager, ComportManager>();
        }

        private void InitDevices(List<SerialPortSetting> settings)
        {
            var manager = Ioc.Resolve<IComportManager>();
            if (manager == null)
            {
                return;
            }
            manager.Create(settings);
            DisposeActions.Add(manager.Dispose);
        }

        private void InitMenu()
        {
            var menus = new List<MenuSetting>() {
                new MenuSetting()
                {
                    Type = typeof(ComportSetting),
                    ViewName = nameof(ComportSetting),
                    Label = "Comport Setting",
                    Geometry = GeometryString.UsbGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menus);
        }
    }
}