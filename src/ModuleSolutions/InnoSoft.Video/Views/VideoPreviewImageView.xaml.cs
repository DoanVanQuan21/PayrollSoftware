using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.Video.ViewModels;

namespace InnoSoft.Video.Views
{
    /// <summary>
    /// Interaction logic for VideoPreviewImageView.xaml
    /// </summary>
    public partial class VideoPreviewImageView : UserControl
    {
        public VideoPreviewImageView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<VideoPreviewImageViewModel>();
        }
    }
}