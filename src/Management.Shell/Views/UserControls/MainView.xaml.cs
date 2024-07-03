using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Shell.ViewModels;
using System.Windows.Controls;

namespace Management.Shell.Views.UserControls
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