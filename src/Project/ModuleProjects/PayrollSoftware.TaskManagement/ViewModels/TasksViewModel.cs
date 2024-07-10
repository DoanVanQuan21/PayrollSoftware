using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.TaskManagement.Services.Contracts;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
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
        
        protected override void RegisterCommand()
        {
            base.RegisterCommand();
        }

        protected override void OnLoaded()
        {
            _taskService.BeginTracking();
            _taskService.UpdateTasks();
        }
        protected override void UnLoaded()
        {
            _taskService.EndTracking();
        }
        public override string Title => "Danh sách công việc";
        public ObservableCollection<Task> TaskToDos => _taskService.TaskToDos;

        public ObservableCollection<Task> TaskInProgesses => _taskService.TaskInProgesses;

        public ObservableCollection<Task> TaskDones => _taskService.TaskDones;
    }
}