using Management.Core.Constants;
using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.Services;
using Management.Devices.Services;
using Management.Devices.Services.Constracts;
using Management.Shell.Services;
using Management.Shell.ViewModels;
using Management.Shell.Views;
using Management.Shell.Views.UserControls;
using Management.UI.Contracts;
using Management.UI.Services;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using System.Diagnostics;
using System.Windows;

namespace Management.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
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
            containerRegistry.RegisterSingleton<IAppManager, AppManager>();
            containerRegistry.RegisterSingleton<IThemeService, ThemeService>();
            containerRegistry.RegisterSingleton<ICustomDialog, CustomDialog>();

            containerRegistry.RegisterSingleton<IDeviceMonitoring, DeviceMonitoring>();
            containerRegistry.RegisterSingleton<IDeviceMonitoringManager, DeviceMonitoringManager>();
            containerRegistry.RegisterSingleton<IDeviceService, DeviceService>();

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