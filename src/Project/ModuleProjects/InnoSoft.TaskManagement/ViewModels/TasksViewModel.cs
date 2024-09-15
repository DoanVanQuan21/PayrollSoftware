using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Services;
using InnoSoft.TaskManagement.Services.Contracts;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task = InnoSoft.Core.Models.TaskManagement.Task;

namespace InnoSoft.TaskManagement.ViewModels
{
    internal class TasksViewModel : BaseRegionViewModel
    {
        private readonly ITaskService _taskService;
        private Task currentTask;

        public Task CurrentTask
        {
            get => currentTask;
            set => SetProperty(ref currentTask, value);
        }
        public ICommand DeleteTaskCommand { get; set; }
        public TasksViewModel() : base()
        {
            _taskService = Ioc.Resolve<ITaskService>();
        }

        protected override void RegisterCommand()
        {
            DeleteTaskCommand = new DelegateCommand<Task>(OnDeleteTask);
            base.RegisterCommand();
        }

        private async void OnDeleteTask(Task task)
        {
            await CustomNotification.Info("Đã xóa thành công");
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