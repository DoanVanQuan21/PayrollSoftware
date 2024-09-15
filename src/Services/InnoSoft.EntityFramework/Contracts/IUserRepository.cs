using InnoSoft.Core.Models.TaskManagement;

namespace InnoSoft.EntityFramework.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> Login(User user);
    }
}