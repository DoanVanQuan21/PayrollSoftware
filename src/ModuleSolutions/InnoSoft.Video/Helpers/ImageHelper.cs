using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using InnoSoft.Core.Constants;
using InnoSoft.Video.Models;
using System.Drawing;
using YoloDotNet.Models;

namespace InnoSoft.Video.Helpers
{
    internal class ImageHelper
    {
        public static Task<DetectionResult?> DrawImage(ImageCV image, IDetection result, int index)
        {
            return Task.Factory.StartNew(() =>
            {
                if (result == null) return null;
                var box = new Rectangle(result.BoundingBox.Location.X, result.BoundingBox.Location.Y, result.BoundingBox.Width, result.BoundingBox.Height);
                var color = ColorTranslator.FromHtml(result.Label.Color);
                CvInvoke.Rectangle(image, box, new MCvScalar(color.B, color.G, color.R), 1);
                CvInvoke.PutText(image, $"OK {Math.Round(result.Confidence * 100)}%", new Point(box.X + 10, box.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(color.B, color.G, color.R), 1);
                return new DetectionResult($"{result.Label.Name}{index}", result.Confidence, box);
            });
        }

        public static Task DrawTextOnImage(ImageCV img, ResultType result, List<string> labels)
        {
            return Task.Factory.StartNew(() =>
            {
                var color = result == ResultType.OK ? new MCvScalar(0, 255, 0) : new MCvScalar(0, 0, 255);
                CvInvoke.PutText(img, $"{result}", new Point(10, 120), FontFace.HersheySimplex, 5, color, 3);
                int y = 150;
                int x = 10;
                //foreach (var label in labels)
                //{
                //    CvInvoke.PutText(img, label, new Point(x, y), FontFace.HersheySimplex, 1, color, 1);
                //    y += 10;
                //}
            });
        }

        public static void ApplyPixelMask(Image<Bgr, byte> img, List<Pixel> pixels, Bgr overlayColor, double opacity)
        {
            int width = img.Width;
            int height = img.Height;

            // Convert opacity to a byte value (0-255)
            byte alpha = (byte)(opacity * 255);

            // Parallel options for better performance
            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            // Process each pixel in parallel
            Parallel.ForEach(pixels, options, pixel =>
            {
                int x = pixel.X;
                int y = pixel.Y;

                // Ensure pixel is within image bounds
                if (x < 0 || x >= width || y < 0 || y >= height)
                    return;

                // Get original pixel colors
                Bgr originalColor = img[y, x];

                // Blend the overlay color with the original color
                byte newBlue = (byte)((originalColor.Blue * (255 - alpha) + overlayColor.Blue * alpha) / 255);
                byte newGreen = (byte)((originalColor.Green * (255 - alpha) + overlayColor.Green * alpha) / 255);
                byte newRed = (byte)((originalColor.Red * (255 - alpha) + overlayColor.Red * alpha) / 255);

                // Set the new color
                img[y, x] = new Bgr(newBlue, newGreen, newRed);
            });
        }
    }
}