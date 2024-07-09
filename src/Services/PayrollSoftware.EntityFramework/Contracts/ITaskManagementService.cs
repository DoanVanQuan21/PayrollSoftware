using PayrollSoftware.EntityFramework.Repositories;
using PayrollSoftware.EntityFramework.Repositories.SchoolManager;
using PayrollSoftware.EntityFramework.Repositories.TaskManagements;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface ITaskManagementService
    {
        UserRepository UserRepository { get; }
        ProjectRepository ProjectRepository { get; }
        TaskRepository TaskRepository { get; }
    }
}