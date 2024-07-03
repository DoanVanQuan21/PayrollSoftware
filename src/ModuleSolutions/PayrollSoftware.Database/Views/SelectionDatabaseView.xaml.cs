using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.Database.ViewModels;

namespace PayrollSoftware.Database.Views
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