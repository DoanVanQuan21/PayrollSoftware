using Microsoft.EntityFrameworkCore;
using PayrollSoftware.EntityFramework.Contracts;
using System.Collections.ObjectModel;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;
using TaskSystem = System.Threading.Tasks.Task;

namespace PayrollSoftware.EntityFramework.Repositories.TaskManagements
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(Core.Models.TaskManagement.TaskManagementContext context) : base(context)
        {
        }

        public Task<ObservableCollection<Task>> GetTasksByStatus(string status)
        {
            return TaskSystem.Factory.StartNew(() =>
            {
                var tasks = new ObservableCollection<Task>();
                var tasksByStatus = _context.Tasks.AsNoTracking().Where(t => t.Status == status);
                if (tasksByStatus == null)
                {
                    return tasks;
                }
                if (!tasksByStatus.Any())
                {
                    return tasks;
                }
                tasks.AddRange(tasksByStatus);
                return tasks;
            });
        }
    }
}