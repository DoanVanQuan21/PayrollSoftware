using PayrollSoftware.Video.Models;

namespace PayrollSoftware.Video.Contracts
{
    internal interface IImageProcess
    {
        Task ColorDetector(ImageCV img);

        Task DectectObject(ImageCV image);
    }
}