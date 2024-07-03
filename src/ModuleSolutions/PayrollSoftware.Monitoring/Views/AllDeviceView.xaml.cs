using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.Monitoring.ViewModels;

namespace PayrollSoftware.Monitoring.Views
{
    /// <summary>
    /// Interaction logic for AllDeviceViewer.xaml
    /// </summary>
    public partial class AllDeviceView : UserControl
    {
        public AllDeviceView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<AllDeivceViewModel>();
        }
    }
}