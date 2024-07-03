using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.Video.ViewModels;

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