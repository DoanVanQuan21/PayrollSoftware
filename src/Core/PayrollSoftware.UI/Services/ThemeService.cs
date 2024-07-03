using HandyControl.Themes;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Constants;
using System.Windows;
using Theme = PayrollSoftware.Core.Constants.Theme;
using PayrollSoftware.UI.Contracts;

namespace PayrollSoftware.UI.Services
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
                    _ = Enum.TryParse<Theme>(themeStr, false, out var appTheme);
                    _appManager.BootSetting.CurrentTheme = appTheme;
                });
            });
        }
    }
}