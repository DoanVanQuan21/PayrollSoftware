using Management.Core.Mvvms;
using Management.SchoolManagement.SettingAccount.ViewModels;
using System.Windows.Controls;

namespace Management.SchoolManagement.SettingAccount.Views
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