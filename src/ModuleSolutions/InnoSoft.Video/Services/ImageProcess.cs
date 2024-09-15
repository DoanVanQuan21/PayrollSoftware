using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using InnoSoft.Core.Constants;
using InnoSoft.Core.Settings.Videos;
using InnoSoft.Video.Contracts;
using InnoSoft.Video.Helpers;
using InnoSoft.Video.Models;
using System.Diagnostics;
using System.Drawing;
using YoloDotNet;
using YoloDotNet.Enums;

using Drawing = System.Drawing;
using ImageConverter = InnoSoft.Video.Helpers.ImageConverter;

namespace InnoSoft.Video.Services
{
    internal class ImageProcess : IImageProcess
    {
        #region Fields

        private Yolo _yolo;

        #endregion Fields

        #region Constructors

        public ImageProcess()
        {
        }

        #endregion Constructors

        #region InitModel

        public Task InitModel(YoloInfo config)
        {
            return Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(config.ModelPath)) return;
                DisposeModel();
                CreateModel(config.ModelPath, config.ModelType, config.UseCuda);
            });
        }

        #endregion InitModel

        #region ProcessImage

        public async Task ProcessImage(ImageCV img, YoloInfo config, ImageProcessSetting imageProcessSetting)
        {
            if (_yolo == null)
            {
                return;
            }
            switch (config.ModelType)
            {
                case ModelType.Classification:
                    await Classification(img, imageProcessSetting);
                    break;

                case ModelType.ObjectDetection:
                    await ObjectDetection(img, imageProcessSetting);
                    break;

                case ModelType.ObbDetection:
                    await ObbDetection(img, imageProcessSetting);
                    break;

                case ModelType.Segmentation:
                    await Segmentation(img, imageProcessSetting);
                    break;

                case ModelType.PoseEstimation:
                    await PoseEstimation(img, imageProcessSetting);
                    break;

                default:
                    break;
            }
        }

        #endregion ProcessImage

        #region Yolos

        private async Task Classification(ImageCV img, ImageProcessSetting imageProcessSetting)
        {
        }

        private async Task ObbDetection(ImageCV img, ImageProcessSetting imageProcessSetting)
        {
            var skimage = ImageConverter.ConvertImageCVToSKImage(img);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var results = _yolo.RunObbDetection(skimage, confidence: imageProcessSetting.Confidence, iou: imageProcessSetting.Iou);
            int count = 1;
            foreach (var result in results)
            {
                var detectionResult = await ImageHelper.DrawImage(img, result, count);
                if (detectionResult == null)
                {
                    continue;
                }
                count++;
            }
            skimage.Dispose();
            Console.WriteLine($"Time: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Stop();
        }

        private async Task ObjectDetection(ImageCV img, ImageProcessSetting imageProcessSetting)
        {
            var skimage = ImageConverter.ConvertImageCVToSKImage(img);
            var results = await _yolo.RunObjectDetectionAsync(skimage, confidence: imageProcessSetting.Confidence, iou: imageProcessSetting.Iou);
            int count = 1;
            var labels = new List<string>();
            foreach (var result in results)
            {
                var detectionResult = await ImageHelper.DrawImage(img, result, count);
                if (detectionResult == null)
                {
                    continue;
                }
                labels.Add($"{result.Label.Name} {Math.Round(result.Confidence)}%");
                count++;
            }
            var isNG = labels.Any(x => x.Contains("NG"));
            skimage.Dispose();

            if (isNG)
            {
                await ImageHelper.DrawTextOnImage(img, ResultType.NG, labels.Where(x => x.ToLower().Contains("ng")).ToList());
                return;
            }
            await ImageHelper.DrawTextOnImage(img, ResultType.OK, labels);
        }

        private async Task PoseEstimation(ImageCV img, ImageProcessSetting imageProcessSetting)
        {
        }

        private async Task Segmentation(ImageCV img, ImageProcessSetting imageProcessSetting)
        {
            var skimage = ImageConverter.ConvertImageCVToSKImage(img);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var results = _yolo.RunSegmentation(skimage, confidence: imageProcessSetting.Confidence, iou: imageProcessSetting.Iou);
            int count = 1;
            foreach (var result in results)
            {
                var pixels = result.SegmentedPixels.Where(p => p.Confidence >= imageProcessSetting.Confidence);
                ImageHelper.ApplyPixelMask(img, pixels.ToList(), new Bgr(Color.Red), 0.5);
                var detectionResult = await ImageHelper.DrawImage(img, result, count);
                if (detectionResult == null)
                {
                    continue;
                }
                count++;
            }
            skimage.Dispose();
            Console.WriteLine($"Time: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Stop();
        }

        #endregion Yolos

        #region EmguCv

        public Task GetContours(ImageCV img, double threshold = 0.7)
        {
            return Task.Run(() =>
            {
                Image<Gray, byte> gray = img.Convert<Gray, byte>().SmoothGaussian(5);

                CvInvoke.Threshold(gray, img, 210, 255, ThresholdType.BinaryInv);
            });
        }

        private float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        #endregion EmguCv

        #region Other

        private Task ColorDetector(ImageCV img)
        {
            return Task.Factory.StartNew(() =>
            {
                img.SmoothGaussian(5);
                using var hsvImage = img.Convert<Hsv, byte>();
                Hsv lower = new(31, 50, 0);
                Hsv higher = new(89, 255, 255);
                var mask = hsvImage.InRange(lower, higher);
                using var contours = new VectorOfVectorOfPoint();
                CvInvoke.GaussianBlur(mask, mask, new Size(9, 9), 2);
                CvInvoke.MorphologyEx(mask, mask, MorphOp.Close, new Mat(), new Point(-1, -1), 2, BorderType.Default, new MCvScalar());

                using Mat hierarchy = new Mat();
                CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                for (int i = 0; i < contours.Size; i++)
                {
                    double contourArea = CvInvoke.ContourArea(contours[i]);
                    if (contourArea > 500) // Điều chỉnh ngưỡng này dựa trên kích thước của đối tượng bạn muốn phát hiện
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                        CvInvoke.Rectangle(img, rect, new MCvScalar(0, 255, 0), 2); // Vẽ với màu xanh lá cây và độ dày 2
                    }
                }
                mask.Dispose();
            });
        }

        private void CreateModel(string modelPath, ModelType modeType, bool isCuda = false, int gpuID = 0)
        {
            try
            {
                _yolo = new Yolo(new YoloDotNet.Models.YoloOptions()
                {
                    OnnxModel = modelPath,
                    ModelType = modeType,
                    Cuda = isCuda,
                    GpuId = gpuID,
                    PrimeGpu = true,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void DisposeModel()
        {
            _yolo?.Dispose();
            _yolo = null;
        }

        private Task<ImageCV> RemoveReflection(ImageCV image)
        {
            return Task.Factory.StartNew(() =>
            {
                using var hsvImage = new Mat();
                using var gray = new Mat();
                using var blurred = new Mat();
                using var thresh = new Mat();
                var dst_TELEA = new ImageCV(image.Width, image.Height);
                using var clahe = new Mat();

                CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);
                var hsvChannels = hsvImage.Split();
                CvInvoke.CLAHE(hsvChannels[2], 2, new Size(8, 8), clahe);

                CvInvoke.Merge(new VectorOfMat(hsvChannels[0], hsvChannels[1], clahe), hsvImage);

                CvInvoke.CvtColor(hsvImage, hsvImage, ColorConversion.Hsv2Bgr);

                CvInvoke.CvtColor(hsvImage, gray, ColorConversion.Bgr2Gray);
                CvInvoke.GaussianBlur(gray, blurred, new Size(3, 3), 0);
                CvInvoke.Threshold(blurred, thresh, 225, 255, ThresholdType.Binary);

                CvInvoke.Inpaint(image, thresh, dst_TELEA, 3, InpaintType.Telea);
                foreach (var channel in hsvChannels)
                {
                    channel.Dispose();
                }
                return dst_TELEA;
            });
        }

        #endregion Other
    }
}