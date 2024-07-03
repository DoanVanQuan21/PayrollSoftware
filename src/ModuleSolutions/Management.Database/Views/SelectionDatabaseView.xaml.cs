using Management.Core.Mvvms;
using Management.Database.ViewModels;
using System.Windows.Controls;

namespace Management.Database.Views
{
    /// <summary>
    /// Interaction logic for SelectionDatabaseView.xaml
    /// </summary>
    public partial class SelectionDatabaseView : UserControl
    {
        public SelectionDatabaseView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<SelectionDatabaseViewModel>();
        }
    }
}