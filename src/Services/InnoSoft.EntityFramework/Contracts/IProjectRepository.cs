using InnoSoft.Core.Models.TaskManagement;
using System.Collections.ObjectModel;

namespace InnoSoft.EntityFramework.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<ObservableCollection<Project>> GetProjects();
        Task<int> GetMaxPage(int row);
    }
}