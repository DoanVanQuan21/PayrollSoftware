using PayrollSoftware.Comport.ViewModels;
using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;

namespace PayrollSoftware.Comport.Views
{
    /// <summary>
    /// Interaction logic for ComportSetting.xaml
    /// </summary>
    public partial class ComportSetting : UserControl
    {
        public ComportSetting()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<ComportSettingViewModel>();
        }

    }
}