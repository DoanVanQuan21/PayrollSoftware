using InnoSoft.Core.Contracts;
using InnoSoft.Core.Events;
using InnoSoft.Core.Mvvms;
using InnoSoft.Shell.Views.UserControls;
using Prism.Events;
using System.Windows;
using System.Windows.Input;
using InnoSoft.Shell.ViewModels;

namespace InnoSoft.Shell.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindowView()
        {
            InitializeComponent();
            viewModel = Ioc.Resolve<MainWindowViewModel>();
            DataContext = viewModel;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

       
    }
}