using InnoSoft.Core.Mvvms;
using System.Windows.Controls;
using InnoSoft.Database.ViewModels;

namespace InnoSoft.Database.Views
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