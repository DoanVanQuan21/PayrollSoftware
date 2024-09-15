using InnoSoft.Core.Models;
using InnoSoft.Core.Mvvms;
using InnoSoft.Shell.ViewModels;
using System.Windows.Controls;

namespace InnoSoft.Shell.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainWindowViewModel viewModel;
        public MainView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainWindowViewModel>();
            DataContext = viewModel;
        }

    }
}