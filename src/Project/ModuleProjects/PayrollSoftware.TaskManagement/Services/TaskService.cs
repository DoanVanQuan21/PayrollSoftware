using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Services;
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
        private readonly IAppManager _appManager;

        public TaskService()
        {
            _taskManagementService = Ioc.Resolve<ITaskManagementService>();
            _appManager = Ioc.Resolve<IAppManager>();
            TaskToDos = new();
            TaskInProgesses = new();
            TaskDones = new();
        }

        public void BeginTracking()
        {
            TaskToDos.CollectionChanged += UpdateTasksToDo;
            TaskInProgesses.CollectionChanged += UpdateTasksInProgess;
            TaskDones.CollectionChanged += UpdateTasksDone;
        }

        public void EndTracking()
        {
            TaskToDos.CollectionChanged -= UpdateTasksToDo;
            TaskInProgesses.CollectionChanged -= UpdateTasksInProgess;
            TaskDones.CollectionChanged -= UpdateTasksDone;
        }

        private async void UpdateTasksDone(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    return;
                }
                var tasks = e.NewItems.Cast<Task>().ToList();
                var tasksNotDone = tasks.Where(t => t.Status != TaskState.DONE).ToList();
                if (!tasksNotDone.Any())
                {
                    return;
                }
                var isUpdated = await _taskManagementService.TaskRepository.UpdateTasks(tasksNotDone, TaskState.DONE);
                if (!isUpdated)
                {
                    await CustomNotification.Warning("Cập nhật trạng thái thất bại!");
                    return;
                }
                await CustomNotification.Success("Cập nhật trạng thái thành công");
            }
            catch (Exception ex)
            {
                await CustomNotification.Error("Cập nhật trạng thái thất bại!");
            }
        }

        private async void UpdateTasksToDo(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    return;
                }
                var tasks = e.NewItems.Cast<Task>().ToList();
                var tasksNotToDo = tasks.Where(t => t.Status != TaskState.TODO).ToList();
                if (!tasksNotToDo.Any())
                {
                    return;
                }
                var isUpdated = await _taskManagementService.TaskRepository.UpdateTasks(tasksNotToDo, TaskState.TODO);
                if (!isUpdated)
                {
                    await CustomNotification.Warning("Cập nhật trạng thái thất bại!");
                    return;
                }
                await CustomNotification.Success("Cập nhật trạng thái thành công");
            }
            catch (Exception ex)
            {
                await CustomNotification.Warning("Cập nhật trạng thái thất bại!");
            }
        }

        private async void UpdateTasksInProgess(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    return;
                }
                var tasks = e.NewItems.Cast<Task>().ToList();
                var tasksNotInProgress = tasks.Where(t => t.Status != TaskState.INPROGESS).ToList();
                if (!tasksNotInProgress.Any())
                {
                    return;
                }
                var isUpdated = await _taskManagementService.TaskRepository.UpdateTasks(tasksNotInProgress, TaskState.INPROGESS);
                if (!isUpdated)
                {
                    await CustomNotification.Warning("Cập nhật trạng thái thất bại!");
                    return;
                }
                await CustomNotification.Success("Cập nhật trạng thái thành công");
            }
            catch (Exception ex)
            {
                await CustomNotification.Warning("Cập nhật trạng thái thất bại!");
            }
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
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.TODO, 1);
            foreach (var task in tasks)
            {
                task.Project = await _taskManagementService.ProjectRepository.GetById(task.ProjectId);
            }
            TaskToDos.AddRange(tasks);
        }

        private async TaskSystem GetTaskInProgess()
        {
            TaskInProgesses.Clear();
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.INPROGESS, 1);
            foreach (var task in tasks)
            {
                task.Project = await _taskManagementService.ProjectRepository.GetById(task.ProjectId);
            }
            TaskInProgesses.AddRange(tasks);
        }

        private async TaskSystem GetTaskDones()
        {
            TaskDones.Clear();
            var tasks = await _taskManagementService.TaskRepository.GetTasksByStatus(TaskState.DONE, 1);
            foreach (var task in tasks)
            {
                task.Project = await _taskManagementService.ProjectRepository.GetById(task.ProjectId);
            }
            TaskDones.AddRange(tasks);
        }
    }
}