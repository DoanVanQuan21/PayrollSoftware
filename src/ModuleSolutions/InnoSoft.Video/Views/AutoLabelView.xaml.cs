using InnoSoft.Core.Mvvms;
using InnoSoft.Video.ViewModels;
using System.Windows.Controls;

namespace InnoSoft.Video.Views
{
    /// <summary>
    /// Interaction logic for AutoLabelView.xaml
    /// </summary>
    public partial class AutoLabelView : UserControl
    {
        public AutoLabelView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<AutoLabelViewModel>();
        }
    }
}