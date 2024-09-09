using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Shell.Views.UserControls;
using PayrollSoftware.Shell.ViewModels;
using Prism.Events;
using System.Windows;
using System.Windows.Input;

namespace PayrollSoftware.Shell.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainWindowViewModel>();
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