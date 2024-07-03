using Management.Video.Models;
using System.Windows;

namespace Management.Video.Contracts
{
    internal interface IImageRender
    {
        Task Render(ImageCV image);

        UIElement GetImageControl();
    }
}