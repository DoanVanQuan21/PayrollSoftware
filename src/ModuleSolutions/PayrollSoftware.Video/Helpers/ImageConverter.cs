using PayrollSoftware.Video.Models;
using SkiaSharp;
using System.Runtime.InteropServices;

namespace PayrollSoftware.Video.Helpers
{
    internal class ImageConverter
    {
        public static SKImage ConvertImageCVToSKImage(ImageCV img)
        {
            // Get the image data from the EmguCV image
            byte[] imageData = img.Bytes;

            // Get image dimensions
            int width = img.Width;
            int height = img.Height;
            int channels = img.NumberOfChannels;

            // Check if the image is in BGR format
            if (channels != 3)
            {
                throw new ArgumentException("Only BGR images are supported.");
            }

            // Create an SKBitmap
            SKBitmap skBitmap = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Premul);

            // Copy the data to the SKBitmap
            IntPtr skBitmapPixels = skBitmap.GetPixels();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int emguIndex = (y * width + x) * channels;
                    int skiaIndex = (y * width + x) * 4;

                    // BGR to BGRA
                    Marshal.Copy(imageData, emguIndex, skBitmapPixels + skiaIndex, 3);
                    Marshal.WriteByte(skBitmapPixels + skiaIndex + 3, 255); // Set alpha channel to 255 (opaque)
                }
            }

            return SKImage.FromBitmap(skBitmap);
        }
    }
}