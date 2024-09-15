using InnoSoft.Video.Models;
using System.Windows;

namespace InnoSoft.Video.Contracts
{
    internal interface IImageRender
    {
        Task Render(ImageCV image);

        UIElement GetImageControl();
    }
}