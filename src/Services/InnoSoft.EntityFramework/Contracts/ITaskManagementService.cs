using InnoSoft.EntityFramework.Repositories;
using InnoSoft.EntityFramework.Repositories.TaskManagements;

namespace InnoSoft.EntityFramework.Contracts
{
    public interface ITaskManagementService
    {
        UserRepository UserRepository { get; }
        ProjectRepository ProjectRepository { get; }
        TaskRepository TaskRepository { get; }
    }
}