using System.Collections.ObjectModel;
using Task = InnoSoft.Core.Models.TaskManagement.Task;

namespace InnoSoft.EntityFramework.Contracts
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        Task<ObservableCollection<Task>> GetTasksByStatus(string status, int projectID);
        Task<bool> UpdateTasks(IList<Task> tasks, string status);
    }
}