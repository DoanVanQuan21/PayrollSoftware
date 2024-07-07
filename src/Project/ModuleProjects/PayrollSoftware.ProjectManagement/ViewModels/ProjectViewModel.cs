using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task = System.Threading.Tasks.Task;

namespace PayrollSoftware.ProjectManagement.ViewModels
{
    internal class ProjectViewModel : ManagementRegionViewModel
    {
        private readonly ITaskManagementService _taskManagementService;

        public ProjectViewModel() : base()
        {
            _taskManagementService = Ioc.Resolve<ITaskManagementService>();
            Projects = new();
        }
        public ICommand LoadedCommand { get;set; }
        protected override void RegisterCommand()
        {
            LoadedCommand = new DelegateCommand(OnLoad);
            base.RegisterCommand();
        }

        private async void OnLoad()
        {
            await GetMaxPage();
        }

        private async Task GetMaxPage()
        {
            MaxPage = await _taskManagementService.ProjectRepository.GetMaxPage(Row);
        }

        public ObservableCollection<Project> Projects { get; set; }
        public override string Title => "Quản lý dự án";
    }
}