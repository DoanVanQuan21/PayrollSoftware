using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Shell.ViewModels;

namespace PayrollSoftware.Shell.Views.UserControls
{
    /// <summary>
    /// Interaction logic for TitleMenu.xaml
    /// </summary>
    public partial class TitleMenu
    {
        public TitleMenu()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<TitleMenuViewModel>();
        }
    }
}