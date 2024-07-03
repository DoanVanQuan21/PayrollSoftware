using Management.Core.Mvvms;
using Management.Shell.ViewModels;
using System.Windows.Controls;

namespace Management.Shell.Views.UserControls
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