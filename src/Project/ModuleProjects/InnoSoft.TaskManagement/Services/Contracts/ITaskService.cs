using System.Collections.ObjectModel;
using Task = InnoSoft.Core.Models.TaskManagement.Task;
using TaskSystem = System.Threading.Tasks.Task;

namespace InnoSoft.TaskManagement.Services.Contracts
{
    public interface ITaskService
    {
        ObservableCollection<Task> TaskToDos { get; }
        ObservableCollection<Task> TaskInProgesses { get; }
        ObservableCollection<Task> TaskDones { get; }

        TaskSystem UpdateTasks();

        void EndTracking();

        void BeginTracking();
    }
}