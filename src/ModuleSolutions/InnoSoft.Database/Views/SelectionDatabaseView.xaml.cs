using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.Database.ViewModels;

namespace InnoSoft.Database.Views
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