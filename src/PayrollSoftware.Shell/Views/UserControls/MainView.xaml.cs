using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Shell.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.Shell.Views.UserControls
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

        private void LsMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menu = e.AddedItems[0] as MenuSetting;
            viewModel.SelectedMenuCommand.Execute(menu);
        }
    }
}