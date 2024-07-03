using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.LiveChart.ViewModels;

namespace PayrollSoftware.LiveChart.Views
{
    /// <summary>
    /// Interaction logic for LiveChartView.xaml
    /// </summary>
    public partial class LiveChartView : UserControl
    {
        public LiveChartView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<LiveChartViewModel>();
        }
    }
}