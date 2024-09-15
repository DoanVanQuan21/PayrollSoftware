using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.SettingAccount.ViewModels;

namespace InnoSoft.SettingAccount.Views
{
    /// <summary>
    /// Interaction logic for SettingAccount.xaml
    /// </summary>
    public partial class SettingAccountView : UserControl
    {
        public SettingAccountView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<SettingAccountViewModel>();
        }
    }
}