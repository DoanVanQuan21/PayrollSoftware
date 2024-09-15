using InnoSoft.Core.Constants;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Events;
using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Services;
using InnoSoft.Shell.Views;
using InnoSoft.Shell.Views.UserControls;
using InnoSoft.UI.Contracts;
using InnoSoft.UI.Services;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using System.Diagnostics;
using System.Windows;
using InnoSoft.Devices.Services.Constracts;
using InnoSoft.Devices.Services;
using InnoSoft.EntityFramework.Context;
using InnoSoft.EntityFramework.Contracts;
using InnoSoft.Shell.ViewModels;
using InnoSoft.Shell.Services;

namespace InnoSoft.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            var t = 0;
        }
        protected override Window CreateShell()
        {
            try
            {
                var startup = Ioc.Resolve<IStartUp>();
                startup.UserProject().Start();
                return Ioc.Container.Resolve<MainWindowView>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        protected override void OnInitialized()
         {
            base.OnInitialized();
            DefaultTheme();
        }

        private async void DefaultTheme()
        {
            var _appManager = Ioc.Resolve<IAppManager>();
            var _themeService = Ioc.Resolve<IThemeService>();
            var eventAggreator = Ioc.Resolve<IEventAggregator>();
            if (_appManager.BootSetting.CurrentTheme == Theme.Light)
            {
                await _themeService.ChangeTheme(Theme.Light.ToString());
                eventAggreator.GetEvent<ChangeThemeEvent>().Publish();

                return;
            }
            await _themeService.ChangeTheme(Theme.Dark.ToString());
            eventAggreator.GetEvent<ChangeThemeEvent>().Publish();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStartUp, StartUp>();
            containerRegistry.RegisterSingleton<ICustomModuleManager, CustomModuleManager>();
            containerRegistry.RegisterSingleton<IAppManager, AppManager>();
            containerRegistry.RegisterSingleton<IThemeService, ThemeService>();
            containerRegistry.RegisterSingleton<ICustomDialog, CustomDialog>();

            containerRegistry.RegisterSingleton<IDeviceMonitoring, DeviceMonitoring>();
            containerRegistry.RegisterSingleton<IDeviceMonitoringManager, DeviceMonitoringManager>();
            containerRegistry.RegisterSingleton<IDeviceService, DeviceService>();
            containerRegistry.RegisterSingleton<ITaskManagementService, TaskManagementService>();

            containerRegistry.RegisterSingleton<MainWindowViewModel>();
            containerRegistry.RegisterSingleton<TitleMenuViewModel>();
            containerRegistry.Register<StartUpViewModel>();
            containerRegistry.RegisterForNavigation<MainView>(nameof(MainView));

            Ioc.AppContainer = containerRegistry.GetContainer();
            Ioc.ContainerRegistry = containerRegistry;
            Ioc.Container = Container;
        }
    }
}