using HandyControl.Attributes;
using InnoSoft.Core.Editors;
using Prism.Mvvm;
using System.ComponentModel;

namespace InnoSoft.Core.Settings.Videos
{
    public class ImageProcessSetting : BindableBase
    {
        private double confidence = 0.1;
        private double iou = 0.7;

        [DisplayName("Confidence")]
        [MaxValue(1.0)]
        [MinValue(0.0)]
        [Editor(typeof(SliderPropertyEditor), typeof(SliderPropertyEditor))]
        public double Confidence
        {
            get { return confidence; }
            set { SetProperty(ref confidence, value); }
        }

        [MaxValue(1.0)]
        [MinValue(0.0)]
        [Editor(typeof(SliderPropertyEditor), typeof(SliderPropertyEditor))]
        public double Iou
        {
            get { return iou; }
            set { SetProperty(ref iou, value); }
        }
    }
}