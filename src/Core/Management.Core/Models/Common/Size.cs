using Prism.Mvvm;

namespace Management.Core.Models.Common
{
    public class Size : BindableBase
    {
        private int width;
        private int height;

        public int Width { get => width; set => SetProperty(ref width, value); }
        public int Height { get => height; set => SetProperty(ref height, value); }
    }
}