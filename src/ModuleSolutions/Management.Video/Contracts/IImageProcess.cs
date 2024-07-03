using Management.Video.Models;

namespace Management.Video.Contracts
{
    internal interface IImageProcess
    {
        Task ColorDetector(ImageCV img);

        Task DectectObject(ImageCV image);
    }
}