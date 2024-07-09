using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;
using TaskSystem = System.Threading.Tasks.Task;
namespace PayrollSoftware.TaskManagement.Services.Contracts
{
    public interface ITaskService
    {
        ObservableCollection<Task> TaskToDos { get; }
        ObservableCollection<Task> TaskInProgesses { get; }
        ObservableCollection<Task> TaskDones { get; }
        TaskSystem UpdateTasks();
    }
}