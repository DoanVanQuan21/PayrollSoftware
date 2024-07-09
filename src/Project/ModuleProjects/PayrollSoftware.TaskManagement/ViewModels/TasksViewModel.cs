using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.TaskManagement.Services.Contracts;
using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;

namespace PayrollSoftware.TaskManagement.ViewModels
{
    internal class TasksViewModel : BaseRegionViewModel
    {
        private readonly ITaskService _taskService;

        public TasksViewModel() : base()
        {
            _taskService = Ioc.Resolve<ITaskService>();
        }

        public override string Title => "Danh sách công việc";
        public ObservableCollection<Task> TaskToDos => _taskService.TaskToDos;

        public ObservableCollection<Task> TaskInProgesses => _taskService.TaskInProgesses;

        public ObservableCollection<Task> TaskDones => _taskService.TaskDones;
    }
}