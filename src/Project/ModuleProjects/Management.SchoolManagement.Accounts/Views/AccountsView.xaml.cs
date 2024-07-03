using Management.Core.Mvvms;
using Management.SchoolManagement.Accounts.ViewModels;
using System.Windows.Controls;

namespace Management.SchoolManagement.Accounts.Views
{
    /// <summary>
    /// Interaction logic for ListAccountView.xaml
    /// </summary>
    public partial class AccountsView : UserControl
    {
        public AccountsView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<AccountsViewModel>();
        }
    }
}