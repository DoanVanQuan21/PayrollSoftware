using PayrollSoftware.Core.Models.SchoolManager;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface IUserRepository
    {
        User? Login(User user);
        bool Update(User user);
    }
}