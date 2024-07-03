using Management.Core.Mvvms;
using Management.Video.ViewModels;
using System.Windows.Controls;

namespace Management.Video.Views
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