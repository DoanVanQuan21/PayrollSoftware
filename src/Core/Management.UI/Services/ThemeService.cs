using HandyControl.Themes;
using Management.Core.Contracts;
using Management.Core.Mvvms;
using Management.UI.Contracts;
using System.Windows;

namespace Management.UI.Services
{
    public class ThemeService : IThemeService
    {
        private IAppManager _appManager;

        public ThemeService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public Task ChangeTheme(string themeStr)
        {
            return Task.Factory.StartNew(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    _ = Enum.TryParse<ApplicationTheme>(themeStr, out var theme);
                    if (ThemeManager.Current.ApplicationTheme == theme)
                    {
                        return;
                    }
                    ThemeManager.Current.ApplicationTheme = theme;
                    _ = Enum.TryParse<Core.Constants.Theme>(themeStr, false, out var appTheme);
                    _appManager.BootSetting.CurrentTheme = appTheme;
                });
            });
        }
    }
}