using InnoSoft.Core.Constants;
using InnoSoft.Core.Context;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Events;
using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Services;
using InnoSoft.Shell.Views.UserControls;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace InnoSoft.Shell.ViewModels
{
    internal class MainWindowViewModel : BaseRegionViewModel
    {
        private const string APP_ICON_DARK = @"..\app_icon_dark.ico";
        private const string APP_ICON_LIGHT = @"..\app_icon_light.ico";
        private readonly IAppManager _appManager;
        private readonly ICustomModuleManager _customModuleManager;
        private MenuSetting currentTab;
        private string iconWindow = @"..\app_icon.ico";
        private bool isOpenSidebar = false;
        private ObservableCollection<MenuSetting>? menuSettings;

        public MainWindowViewModel() : base()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            _customModuleManager = Ioc.Resolve<ICustomModuleManager>();
            MenuSettings = new();
            InitMenu();
            SetMainView(new StartUpView());
        }

        public ICommand? ClosedTabCommand { get; set; }
        public MenuSetting CurrentTab { get => currentTab; set => SetProperty(ref currentTab, value); }
        public string IconWindow { get => iconWindow; set => SetProperty(ref iconWindow, value); }
        public bool IsOpenSidebar { get => isOpenSidebar; set => SetProperty(ref isOpenSidebar, value); }

        public ObservableCollection<MenuSetting>? MenuSettings
        { get => menuSettings; set { SetProperty(ref menuSettings, value); } }

        public ICommand? SelectedMenuCommand { get; set; }
        public ICommand? ShutDownCommand { get; set; }
        public override string Title => "Home";
        public string? Fullname { get => BootSetting.CurrentUser?.FullName; }

        protected override void RegisterCommand()
        {
            SelectedMenuCommand = new DelegateCommand<MenuSetting>(OnSelectedMenu);
            ShutDownCommand = new DelegateCommand(OnShutDown);
            ClosedTabCommand = new DelegateCommand<RoutedEventArgs>(OnClosedTab);
        }

        protected override void RegisterEvent()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
            EventAggregator.GetEvent<OpenSidebarEvent>().Subscribe(OnOpenSidebar);
            EventAggregator.GetEvent<ChangeThemeEvent>().Subscribe(OnChangeTheme);
            EventAggregator.GetEvent<ExitApplicationEvent>().Subscribe(OnShutDown);
        }

        private async Task DisposeModules()
        {
            ShowProgressBar();
            foreach (var module in _customModuleManager.CustomModules)
            {
                module.Dispose();
                await Task.Delay(500);
            }
            CloseDialog();
        }

        private void InitMenu()
        {
            var menuSettings = new ObservableCollection<MenuSetting>();
            MenuSettings?.Clear();
            foreach (var menu in RootContext.MenuSettings)
            {
                menuSettings.Add(menu);
            }
            MenuSettings.AddRange(menuSettings);
        }

        private void OnChangeTheme()
        {

        }

        private async void OnClosedTab(RoutedEventArgs args)
        {
            try
            {
                var tab = args.OriginalSource as MenuSetting;
                await CustomNotification.Success($"Closed {tab.Label}");
            }
            catch (Exception)
            {
                await CustomNotification.Info("Có lỗi xảy ra, không thể xóa tab hiện tại!.");
            }
        }

        private async void OnLogginSuccess(bool isLoginSucess)
        {
            if (isLoginSucess)
            {
                SetMainView(new MainView());
                SetMainPage(new());
                CloseDialog();
                await CustomNotification.Success("Đăng nhập thành công!.");
                return;
            }
            CloseDialog();
            await CustomNotification.Error("Login failed");
        }

        private void OnOpenSidebar()
        {
            if (IsOpenSidebar)
            {
                IsOpenSidebar = false;
                return;
            }
            IsOpenSidebar = true;
        }

        private async void OnSelectedMenu(MenuSetting setting)
        {
            CurrentTab = setting;
            AppRegion.Title = setting.Label;
        }

        private async void OnShutDown()
        {
            await DisposeModules();
            Application.Current.Shutdown();
        }
    }
}