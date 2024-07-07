using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.ProjectManagement.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.ProjectManagement.Views
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        public ProjectsView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<ProjectViewModel>();
        }
    }
}