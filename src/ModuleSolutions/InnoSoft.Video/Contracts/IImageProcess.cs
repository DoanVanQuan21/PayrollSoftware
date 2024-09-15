using InnoSoft.Core.Settings.Videos;
using InnoSoft.Video.Models;

namespace InnoSoft.Video.Contracts
{
    internal interface IImageProcess
    {
        Task GetContours(ImageCV img, double threshold = 0.7);

        Task InitModel(YoloInfo config);

        Task ProcessImage(ImageCV img, YoloInfo config, ImageProcessSetting imageProcessSetting);
    }
}