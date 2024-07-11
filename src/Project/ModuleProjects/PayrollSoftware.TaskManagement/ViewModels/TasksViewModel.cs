using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.TaskManagement.Services.Contracts;
using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;

namespace PayrollSoftware.TaskManagement.ViewModels
{
    internal class TasksViewModel : BaseRegionViewModel
    {
        private readonly ITaskService _taskService;
        private Task currentTask;

        public Task CurrentTask { get => currentTask; set => SetProperty(ref currentTask,value); }

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