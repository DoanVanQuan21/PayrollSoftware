using Management.Core.Mvvms;
using Management.Shell.ViewModels;
using System.Windows.Controls;

namespace Management.Shell.Views.UserControls
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