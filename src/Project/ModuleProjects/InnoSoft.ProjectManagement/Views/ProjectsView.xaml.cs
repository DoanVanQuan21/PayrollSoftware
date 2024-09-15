using InnoSoft.Core.Mvvms;
using InnoSoft.ProjectManagement.ViewModels;
using System.Windows.Controls;

namespace InnoSoft.ProjectManagement.Views
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