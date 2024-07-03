using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.SettingAccount.ViewModels;

namespace PayrollSoftware.SettingAccount.Views
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