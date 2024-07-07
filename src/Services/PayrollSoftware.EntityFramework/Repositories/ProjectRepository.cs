using Microsoft.EntityFrameworkCore;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.EntityFramework.Contracts;
using System.Collections.ObjectModel;
using Task = System.Threading.Tasks.Task;

namespace PayrollSoftware.EntityFramework.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskManagementContext context) : base(context)
        {
        }

        public override Task<Project?> GetByCode(string code)
        {
            return Task.Factory.StartNew(() =>
            {
                return _context.Projects.FirstOrDefault(p => p.ProjectCode == code);
            });
        }

        public override Task<Project?> GetById(long id)
        {
            return Task.Factory.StartNew(() =>
            {
                return _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            });
        }

        public Task<int> GetMaxPage(int row)
        {
            return Task.Factory.StartNew(() =>
            {
                var t = _context.Projects.ToList();
                var totalRow = _context.Projects.Count();
                var maxPage = totalRow / row;
                if (totalRow % row == 0)
                {
                    return maxPage;
                }
                return maxPage + 1;
            });
        }

        public Task<ObservableCollection<Project>> GetProjects()
        {
            return Task.Factory.StartNew(() =>
            {
                var projects = _context.Projects.AsNoTracking().ToList();
                if (projects == null || projects?.Count <= 0)
                {
                    return new ObservableCollection<Project>();
                }
                return new ObservableCollection<Project>(projects);
            });
        }

        public override Task<ObservableCollection<Project>> GetRecordsBySize(int page, int pageSize)
        {
            return Task.Factory.StartNew(() =>
            {
                var projects = new ObservableCollection<Project>();
                var startAt = page * pageSize;
                var records = _context.Projects.Skip(startAt).Take(pageSize);
                if (records == null)
                {
                    return projects;
                }
                if (!records.Any())
                {
                    return projects;
                }
                projects.AddRange(records);
                return projects;
            });
        }
    }
}