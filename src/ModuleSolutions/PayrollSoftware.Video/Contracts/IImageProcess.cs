using PayrollSoftware.Core.Settings.Videos;
using PayrollSoftware.Video.Models;

namespace PayrollSoftware.Video.Contracts
{
    internal interface IImageProcess
    {
        Task GetContours(ImageCV img, double threshold = 0.7);

        Task InitModel(YoloInfo config);

        Task ProcessImage(ImageCV img, YoloInfo config, ImageProcessSetting imageProcessSetting);
    }
}