using InnoSoft.Core.Constants;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace InnoSoft.UI.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isLogin = (bool)value;
            return isLogin ? Visibility.VISIBLE : Visibility.HIDDEN;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ThemeToBoolConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parseOk = Enum.TryParse<Theme>(value.ToString(), out var theme);
            if (!parseOk) { return parseOk; }
            if (theme == Theme.Light)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parseOk = Enum.TryParse<Theme>(value.ToString(), out var theme);
            if (!parseOk) { return parseOk; }
            if (theme == Theme.Light)
            {
                return false;
            }
            return true;
        }
    }

    public class EnumToCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetValues(value.GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BackgroundTransparentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter?.ToString();
            var paramerters = param?.Split(",");
            if (paramerters?.Length < 0)
            {
                return Visibility.HIDDEN;
            }
            var compareValue = value?.ToString();
            var isExist = paramerters.FirstOrDefault(p => p == compareValue);
            if (isExist != null)
            {
                return Visibility.VISIBLE;
            }
            return Visibility.HIDDEN;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}