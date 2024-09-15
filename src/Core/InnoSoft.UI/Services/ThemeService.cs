using HandyControl.Themes;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Constants;
using System.Windows;
using Theme = InnoSoft.Core.Constants.Theme;
using InnoSoft.UI.Contracts;

namespace InnoSoft.UI.Services
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