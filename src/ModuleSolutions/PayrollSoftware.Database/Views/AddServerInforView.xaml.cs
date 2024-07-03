using PayrollSoftware.Core.Mvvms;
using System.Windows.Controls;
using PayrollSoftware.Database.ViewModels;

namespace PayrollSoftware.Database.Views
{
    /// <summary>
    /// Interaction logic for AddServerInforView.xaml
    /// </summary>
    public partial class AddServerInforView : UserControl
    {
        public AddServerInforView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<AddServerInforViewModel>();
        }
    }
}