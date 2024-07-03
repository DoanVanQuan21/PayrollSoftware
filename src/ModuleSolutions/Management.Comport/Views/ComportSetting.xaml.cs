using Management.Comport.ViewModels;
using Management.Core.Mvvms;
using System.Windows.Controls;

namespace Management.Comport.Views
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