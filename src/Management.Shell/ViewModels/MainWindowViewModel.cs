using Management.Core.Constants;
using Management.Core.Context;
using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.Services;
using Management.Shell.Views.UserControls;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Management.Shell.ViewModels
{
    internal class MainWindowViewModel : BaseRegionViewModel
    {
        private const string APP_ICON_LIGHT = @"..\app_icon_light.ico";
        private const string APP_ICON_DARK = @"..\app_icon_dark.ico";
        private readonly IAppManager _appManager;
        private string iconWindow = @"..\app_icon.ico";
        private bool isOpenSidebar = false;
        private ObservableCollection<MenuSetting>? menuSettings;
        private MenuSetting currentTab;

        public MainWindowViewModel() : base()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            MenuSettings = new();
            InitMenu();
            SetMainView(new StartUpView());
        }

        public ObservableCollection<MenuSetting> AppTabs => RootContext.AppTabs;
        public ICommand? ClosedTabCommand { get; set; }
        public MenuSetting CurrentTab { get => currentTab; set => SetProperty(ref currentTab, value); }
        public string IconWindow { get => iconWindow; set => SetProperty(ref iconWindow, value); }
        public bool IsOpenSidebar { get => isOpenSidebar; set => SetProperty(ref isOpenSidebar, value); }

        public ObservableCollection<MenuSetting>? MenuSettings
        { get => menuSettings; set { SetProperty(ref menuSettings, value); } }

        public ICommand? SelectedMenuCommand { get; set; }
        public override string Title => "Home";

        protected override void RegisterCommand()
        {
            SelectedMenuCommand = new DelegateCommand<MenuSetting>(OnSelectedMenu);
            ClosedTabCommand = new DelegateCommand<RoutedEventArgs>(OnClosedTab);
        }

        protected override void RegisterEvent()
        {
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
            EventAggregator.GetEvent<OpenSidebarEvent>().Subscribe(OnOpenSidebar);
            EventAggregator.GetEvent<ChangeThemeEvent>().Subscribe(OnChangeTheme);
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

        private bool IsTabExist(MenuSetting menu)
        {
            var tab = RootContext.AppTabs.FirstOrDefault(t => t.Type == menu.Type);
            if (tab == null)
            {
                return false;
            }
            return true;
        }

        private void OnChangeTheme()
        {
            if (_appManager.BootSetting.CurrentTheme == Theme.Light)
            {
                IconWindow = APP_ICON_DARK;
                return;
            }
            IconWindow = APP_ICON_LIGHT;
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
                return;
            }
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
            if (setting == null)
            {
                await CustomNotification.Warning("Chức năng này hiện tại chưa có!");
                return;
            }
            var isExist = IsTabExist(setting);
            if (isExist)
            {
                await CustomNotification.Info($"{setting.Label} đã có!.");
                return;
            }
            RootContext.AppTabs.Add(setting);
            CurrentTab = setting;
        }
    }
}