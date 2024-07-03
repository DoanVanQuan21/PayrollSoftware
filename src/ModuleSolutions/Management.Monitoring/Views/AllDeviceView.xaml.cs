using Management.Core.Mvvms;
using Management.Monitoring.ViewModels;
using System.Windows.Controls;

namespace Management.Monitoring.Views
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