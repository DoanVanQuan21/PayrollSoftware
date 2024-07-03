using Management.Core.Mvvms;
using Management.LiveChart.ViewModels;
using System.Windows.Controls;

namespace Management.LiveChart.Views
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