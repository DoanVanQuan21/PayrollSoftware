using PayrollSoftware.Core.Models.TaskManagement;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> Login(User user);
    }
}