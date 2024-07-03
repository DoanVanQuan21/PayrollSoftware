using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Shell.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.Shell.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class StartUpView : UserControl
    {
        public StartUpView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<StartUpViewModel>();
        }
    }
}