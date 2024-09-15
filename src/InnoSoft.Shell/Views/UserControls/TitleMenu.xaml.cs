using InnoSoft.Core.Mvvms;
using InnoSoft.Shell.ViewModels;
using System.Windows.Controls;

namespace InnoSoft.Shell.Views.UserControls
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