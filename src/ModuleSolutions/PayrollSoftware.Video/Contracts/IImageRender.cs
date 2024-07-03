using PayrollSoftware.Video.Models;
using System.Windows;

namespace PayrollSoftware.Video.Contracts
{
    internal interface IImageRender
    {
        Task Render(ImageCV image);

        UIElement GetImageControl();
    }
}