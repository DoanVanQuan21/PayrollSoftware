using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Shell.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.Shell.Views.UserControls
{
    /// <summary>
    /// Interaction logic for TitleMenu.xaml
    /// </summary>
    public partial class TitleMenu : UserControl
    {
        public TitleMenu()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<TitleMenuViewModel>();
        }
    }
}