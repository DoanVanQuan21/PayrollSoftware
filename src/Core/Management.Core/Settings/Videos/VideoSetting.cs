using Management.Core.Models.Common;

namespace Management.Core.Settings.Videos
{
    public class VideoSetting : BaseSetting
    {
        private string devicePath;
        private string hardwareName;

        public Size PreviewSize { get; set; }
        public string DevicePath { get => devicePath; set => SetProperty(ref devicePath, value); }
        public string HardwareName { get => hardwareName; set => SetProperty(ref hardwareName,value); }
        public VideoSetting()
        {
            PreviewSize = new Size();
            DevicePath = string.Empty;
        }
    }
}