using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Mvvms;
using Management.Shell.ViewModels;
using Management.Shell.Views.UserControls;
using Prism.Events;
using System.Windows;
using System.Windows.Input;

namespace Management.Shell.Views
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