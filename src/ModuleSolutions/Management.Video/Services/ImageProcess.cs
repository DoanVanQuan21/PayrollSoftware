using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Management.Video.Contracts;
using Management.Video.Models;
using System.Drawing;
using System.IO;

namespace Management.Video.Services
{
    internal class ImageProcess : IImageProcess
    {
        private const string YOLO_CONFIG = @"D:\Quan\yolo\yolov3.cfg";
        private const string YOLO_WRIGHT = @"D:\Quan\yolo\yolov3.weights";
        private const string YOLO_NAMES = @"D:\Quan\yolo\coco.names";
        private Net yoloNet;
        private List<string> classLabels = new();

        public ImageProcess()
        {
            LoadYoloModel().GetAwaiter();
            LoadYoloNames().GetAwaiter();
        }

        private Task LoadYoloModel()
        {
            return Task.Factory.StartNew(() =>
            {
                yoloNet = DnnInvoke.ReadNetFromDarknet(YOLO_CONFIG, YOLO_WRIGHT);
                yoloNet.SetPreferableBackend(Emgu.CV.Dnn.Backend.OpenCV);
                yoloNet.SetPreferableTarget(Target.Cpu);
            });
        }
        private Task<VectorOfMat> GetOutput(ImageCV image)
        {
            return Task.Factory.StartNew(() => {
                var inputBlob = DnnInvoke.BlobFromImage(image, 1 / 255.0, new Size(416, 416), new MCvScalar(0, 0, 0), true, false);
                yoloNet?.SetInput(inputBlob);
                VectorOfMat output = new VectorOfMat();
                yoloNet?.Forward(output, yoloNet?.UnconnectedOutLayersNames);
                inputBlob.Dispose();
                return output;
            });
        }
        private Task<(List<Rectangle>, List<float>, List<int>)> ProcessOuput(ImageCV image,VectorOfMat output)
        {
            return Task.Factory.StartNew(() => {
                // Xử lý kết quả đầu ra
                var confidenceThreshold = 0.5f; // Ngưỡng độ tin cậy
                var nmsThreshold = 0.4f; // Ngưỡng NMS (Non-Maxima Suppression)
                List<Rectangle> boxes = new();
                List<float> confidences = new();
                List<int> classIds = new();
                for (int i = 0; i < output.Size; i++)
                {
                    var level = output[i];
                    var data = (float[,])level.GetData();

                    for (int j = 0; j < data.GetLength(0); j += 85) // YOLO đầu ra 85 giá trị cho mỗi phát hiện
                    {
                        var row = Enumerable.Range(0, data.GetLength(1)).Select(x => data[j, x]).ToArray();
                        var rowScore = row.Skip(5).ToList();
                        var classID = rowScore.IndexOf(rowScore.Max());
                        var actualConfidence = rowScore[classID];
                        if (actualConfidence >= confidenceThreshold)
                        {
                            var centerX = (int)(row[0] * image.Width);
                            var centerY = (int)(row[1] * image.Height);
                            var boxWidth = (int)(row[2] * image.Width);
                            var boxHeight = (int)(row[3] * image.Height);
                            var x = (int)(centerX - boxWidth / 2);
                            var y = (int)(centerY - boxHeight / 2);
                            boxes.Add(new System.Drawing.Rectangle(x, y, boxWidth, boxHeight));
                            classIds.Add(classID);
                            confidences.Add(actualConfidence);
                        }
                    }
                    level.Dispose();
                }
                return (boxes,confidences,classIds);
            });
        }
        public Task DectectObject(ImageCV image)
        {
            return Task.Factory.StartNew(async () =>
            {
                var output = await GetOutput(image);
                var (boxes, confidences, classIds) = await ProcessOuput(image, output);
                // Áp dụng Non-Maxima Suppression để lọc các bounding box không cần thiết
                var bestIndexs = DnnInvoke.NMSBoxes(boxes.ToArray(), confidences.ToArray(), confidenceThreshold, nmsThreshold);

                // Vẽ bounding box lên ảnh gốc
                foreach (int idx in bestIndexs)
                {
                    if (idx >= classIds.Count)
                    {
                        continue;
                    }
                    var box = boxes[idx];
                    var id = classIds[idx];
                    if (id >= classLabels.Count)
                    {
                        continue;
                    }
                    string label = classLabels[classIds[idx]];
                    // Lọc các đối tượng màu xanh
                    CvInvoke.Rectangle(image, box, new MCvScalar(0, 255, 0), 2); // Vẽ với màu xanh lá cây và độ dày 2
                    CvInvoke.PutText(image, label, new Point(box.X, box.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 255, 0), 1);
                }
                output.Dispose();
                boxes.Clear();
                confidences.Clear();
                classIds.Clear();
                classIds = null;
                confidences = null;
                boxes = null;
            });
        }

        private Task LoadYoloNames()
        {
            return Task.Factory.StartNew(() =>
            {
                var names = File.ReadAllLines(YOLO_NAMES);
                if (names == null || names?.Length <= 0)
                {
                    return;
                }
                classLabels.AddRange(names);
            });
        }

        public Task ColorDetector(ImageCV img)
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

                // Adaptive Thresholding để làm sắc nét đối tượng
                //CvInvoke.AdaptiveThreshold(mask, mask, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 11, 2);

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
    }

    internal class Detection
    {
        public string Label { get; set; }
        public Rectangle Box { get; set; }
    }
}