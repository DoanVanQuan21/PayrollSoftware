using PayrollSoftware.Core.Models.TaskManagement;
using System.Collections.ObjectModel;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<ObservableCollection<Project>> GetProjects();
    }
}