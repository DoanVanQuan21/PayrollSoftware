using InnoSoft.Core.Mvvms;
using InnoSoft.Shell.ViewModels;
using System.Windows.Controls;

namespace InnoSoft.Shell.Views.UserControls
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