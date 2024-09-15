using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.Comport.ViewModels;

namespace InnoSoft.Comport.Views
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