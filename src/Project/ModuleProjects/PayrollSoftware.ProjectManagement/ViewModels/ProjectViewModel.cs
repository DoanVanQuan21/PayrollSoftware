using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using System.Collections.ObjectModel;

namespace PayrollSoftware.ProjectManagement.ViewModels
{
    internal class ProjectViewModel : ManagementRegionViewModel
    {
        public override string Title => "Quản lý dự án";
        public ObservableCollection<Project> Projects { get; set; }
        public ProjectViewModel()
        {
            Projects = new();
        }
    }
}