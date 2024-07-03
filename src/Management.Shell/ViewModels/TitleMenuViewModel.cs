using Management.Core.Constants;
using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.Services;
using Management.Devices.Services.Constracts;
using Management.Shell.Views.UserControls;
using Management.UI.Contracts;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace Management.Shell.ViewModels
{
    public class TitleMenuViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        private readonly IDeviceMonitoringManager _deviceManager;
        private readonly IThemeService _themeService;
        private Theme theme;

        public TitleMenuViewModel()
        {
            _deviceManager = Ioc.Resolve<IDeviceMonitoringManager>();
            _themeService = Ioc.Resolve<IThemeService>();
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public BootSetting BootSetting { get => _appManager.BootSetting; }
        public ICommand ChangeDatabaseCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public string? Fullname { get => BootSetting.CurrentUser?.Fullname; }
        public ICommand LogoutCommand { get; set; }
        public ICommand OpenSideBarCommand { get; set; }
        public ICommand SaveSettingCommand { get; set; }

        public Theme Theme
        {
            get { return theme; }
            set
            {
                SetProperty(ref theme, value);
            }
        }

        public override string Title => "Menu";

        protected override void RegisterCommand()
        {
            LogoutCommand = new DelegateCommand(OnLogout);
            CloseCommand = new DelegateCommand(OnCloseApp);
            KeyUpCommand = new DelegateCommand<string>(OnKeyUp);
            ChangeThemeCommand = new DelegateCommand(OnChangeTheme);
            ChangeDatabaseCommand = new DelegateCommand(OnChangeDatabase);
            OpenSideBarCommand = new DelegateCommand(OnOpenSideBar);
            SaveSettingCommand = new DelegateCommand(OnSaveSetting);
        }

        private async void OnSaveSetting()
        {
            try
            {
                _appManager.Save();
                await CustomNotification.Success("Lưu cài đặt thành công!.");
            }
            catch (Exception)
            {
                await CustomNotification.Error("Lưu cài đặt thất bại!.");
            }
        }

        private async void DefaultTheme()
        {
            if (_appManager.BootSetting.CurrentTheme == Theme.Light)
            {
                await _themeService.ChangeTheme(Theme.Light.ToString());
                EventAggregator.GetEvent<ChangeThemeEvent>().Publish();

                return;
            }
            await _themeService.ChangeTheme(Theme.Dark.ToString());
            EventAggregator.GetEvent<ChangeThemeEvent>().Publish();
        }

        private void OnChangeDatabase()
        {
            _appManager.BootSetting.IsSelectedDatabase = false;
            IsLogin = false;
            BootSetting.CurrentUser = null;
            DefaultView();
            AppRegion.MainRegion = new StartUpView();
        }

        private async void OnChangeTheme()
        {
            if (_appManager.BootSetting.CurrentTheme == Theme.Light)
            {
                await _themeService.ChangeTheme(Theme.Dark.ToString());
                EventAggregator.GetEvent<ChangeThemeEvent>().Publish();
                return;
            }
            await _themeService.ChangeTheme(Theme.Light.ToString());
            EventAggregator.GetEvent<ChangeThemeEvent>().Publish();
        }

        private void OnCloseApp()
        {
            Application.Current.Shutdown();
        }

        private async void OnKeyUp(string obj)
        {
            await _deviceManager.Search(obj);
        }

        private void OnLogout()
        {
            IsLogin = false;
            DefaultView();
            AppRegion.MainRegion = new StartUpView();
            BootSetting.CurrentUser = null;
        }

        private void OnMaxApp()
        {
            var window = Application.Current.MainWindow;
            if (window == null) { return; }
            if (window.WindowState == WindowState.Normal)
            {
                window.WindowState = WindowState.Maximized;
                return;
            }
            window.WindowState = WindowState.Normal;
        }

        private void OnOpenSideBar()
        {
            EventAggregator.GetEvent<OpenSidebarEvent>().Publish();
        }
    }
}