using PayrollSoftware.Core.Models.Common;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Drawing;

namespace PayrollSoftware.Video.Models
{
    internal class AutoLabel : BindableBase
    {
        private string? fileName;
        private string? filePath;

        private ImageCV? image;
        public AutoLabel()
        {
            Results = new();
        }

        public string? FileName
        {
            get { return fileName; }
            set { SetProperty(ref fileName, value); }
        }

        public string? FilePath
        {
            get { return filePath; }
            set { SetProperty(ref filePath, value); }
        }

        public ImageCV? Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        public ObservableCollection<KeyValue<string, Rectangle>> Results { get; set; }
    }
}