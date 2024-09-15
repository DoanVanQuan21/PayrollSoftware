using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.LiveChart.ViewModels;

namespace InnoSoft.LiveChart.Views
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