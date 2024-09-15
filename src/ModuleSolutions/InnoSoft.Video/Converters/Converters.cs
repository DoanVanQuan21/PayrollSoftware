using InnoSoft.Video.Models;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InnoSoft.Video.Converters
{
    public class ImageCVToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var current = value as AutoLabel;
            if (current == null)
            {
                return null;
            }
            var source = new WriteableBitmap(current.Image.Width, current.Image.Height, 96, 96, PixelFormats.Bgr24, null);
            source.Lock();
            IntPtr backBuffer = source.BackBuffer;
            Marshal.Copy(current.Image.Bytes, 0, backBuffer, current.Image.Bytes.Length);
            source.AddDirtyRect(new Int32Rect(0, 0, current.Image.Width, current.Image.Height));
            source.Unlock();
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}