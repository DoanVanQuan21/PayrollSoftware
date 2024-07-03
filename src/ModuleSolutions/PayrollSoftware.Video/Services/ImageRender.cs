using Emgu.CV.Structure;
using Emgu.CV;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SharpDX.Direct3D11;
using SharpDX.Direct3D9;
using PayrollSoftware.Video.Contracts;
using PayrollSoftware.Video.Models;

namespace PayrollSoftware.Video.Services
{
    internal class ImageRender : IImageRender
    {
        private readonly Image _image;
        private readonly WriteableBitmap _source;
        private readonly int _width;
        private readonly int _height;

        public ImageRender(int width, int height)
        {
            _image = new()
            {
            };
            _source = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
            _image.Source = _source;
            RenderOptions.SetBitmapScalingMode(_image, BitmapScalingMode.LowQuality);
            _width = width;
            _height = height;
        }

        public UIElement GetImageControl()
        {
            return _image;
        }

        public Task Render(ImageCV image)
        {
            return Task.Factory.StartNew(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _source.Lock();
                    try
                    {
                        if (image.Width == _source.PixelWidth && image.Height == _source.PixelHeight)
                        {
                            IntPtr backBuffer = _source.BackBuffer;
                            Marshal.Copy(image.Bytes, 0, backBuffer, image.Bytes.Length);
                        }
                        _source.AddDirtyRect(new Int32Rect(0, 0, image.Width, image.Height));
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                    finally
                    {
                        _source.Unlock();
                    }
                });
            });
        }
    }
}