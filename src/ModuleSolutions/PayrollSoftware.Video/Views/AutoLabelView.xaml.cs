using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Video.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.Video.Views
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