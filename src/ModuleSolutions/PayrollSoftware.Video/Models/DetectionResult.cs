using System.Drawing;

namespace PayrollSoftware.Video.Models
{
    public class DetectionResult
    {
        public string Label { get; set; }
        public double Confidence { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool Result => Label?.Contains("NG")==false;
        public DetectionResult()
        {
            BoundingBox = new Rectangle();
        }

        public DetectionResult(string label, double confidence, Rectangle boundingBox)
        {
            Label = label;
            Confidence = confidence;
            BoundingBox = boundingBox;
        }

        public override string ToString()
        {
            return $"Label: {Label}, Confidence: {Confidence}, BoundingBox: {BoundingBox}";
        }
    }
}