using PayrollSoftware.EntityFramework.Repositories;
using PayrollSoftware.EntityFramework.Repositories.SchoolManager;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface ITaskManagementService
    {
        UserRepository UserRepository { get; }
        ProjectRepository ProjectRepository { get; }
    }
}