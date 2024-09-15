using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.Monitoring.ViewModels;

namespace InnoSoft.Monitoring.Views
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