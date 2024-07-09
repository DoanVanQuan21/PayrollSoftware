using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        Task<ObservableCollection<Task>> GetTasksByStatus(string status, int projectID, int userID);
    }
}