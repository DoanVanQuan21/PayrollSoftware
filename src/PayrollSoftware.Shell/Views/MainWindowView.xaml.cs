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
    public partial class MainWindowView : HandyControl.Controls.Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<MainWindowViewModel>();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            NonClientAreaContent = new TitleMenu();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Ioc.Resolve<IEventAggregator>().GetEvent<ExitApplicationEvent>().Publish();
            Application.Current.Shutdown();
        }
    }
}