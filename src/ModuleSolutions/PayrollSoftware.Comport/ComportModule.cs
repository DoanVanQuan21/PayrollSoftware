using PayrollSoftware.Comport.Views;
using PayrollSoftware.Comport.Contracts;
using PayrollSoftware.Comport.Services;
using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Settings.Comports;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.UI.Geometry;
using Prism.Ioc;

namespace PayrollSoftware.Comport
{
    public class ComportModule : BasePrismModule
    {
        private IDeviceService deviceService;
        public override string ModuleName => DllName.ComportModule;

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