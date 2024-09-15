using InnoSoft.Core.Mvvms;
using System.Windows;
using System.Windows.Controls;
using InnoSoft.Auth.ViewModels;

namespace InnoSoft.Auth.Views.UserControls
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