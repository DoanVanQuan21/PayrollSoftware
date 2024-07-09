using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.TaskManagement.Services.Contracts;
using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;
using TaskSystem = System.Threading.Tasks.Task;

namespace PayrollSoftware.TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskManagementService _taskManagementService;

        public TaskService()
        {
            _taskManagementService = Ioc.Resolve<ITaskManagementService>();
            TaskToDos = new();
            TaskInProgesses = new();
            TaskToDos = new();
        }

        public ObservableCollection<Task> TaskToDos { get; private set; }

        public ObservableCollection<Task> TaskInProgesses { get; private set; }

        public ObservableCollection<Task> TaskDones { get; private set; }

        public async TaskSystem UpdateTasks()
        {
            await GetTaskToDos();
            await GetTaskInProgess();
            await GetTaskDones();
        }

        private async TaskSystem GetTaskToDos()
        {
            TaskToDos.Clear();
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.TODO);
            TaskToDos.AddRange(tasks);
        }

        private async TaskSystem GetTaskInProgess()
        {
            TaskInProgesses.Clear();
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.INPROGESS);
            TaskInProgesses.AddRange(tasks);
        }

        private async TaskSystem GetTaskDones()
        {
            TaskDones.Clear();
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.DONE);
            TaskDones.AddRange(tasks);
        }
    }
}