using PayrollSoftware.Auth.ViewModels;
using PayrollSoftware.Core.Mvvms;
using System.Windows;
using System.Windows.Controls;

namespace Management.Auth.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginMedicineView.xaml
    /// </summary>
    public partial class LoginMedicineView : UserControl
    {
        public LoginMedicineView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<LoginMedicineViewModel>();
        }
    }
}