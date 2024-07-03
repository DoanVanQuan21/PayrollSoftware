using Management.Core.Mvvms;
using Management.Database.ViewModels;
using System.Windows.Controls;

namespace Management.Database.Views
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