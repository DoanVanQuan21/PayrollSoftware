using Management.Core.Models.SchoolManager;

namespace Management.EntityFramework.Contracts
{
    public interface IUserRepository
    {
        User? Login(User user);
        bool Update(User user);
    }
}