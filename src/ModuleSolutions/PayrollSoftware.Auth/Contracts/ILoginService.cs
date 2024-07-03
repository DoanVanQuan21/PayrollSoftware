using PayrollSoftware.Core.Models.SchoolManager;

namespace PayrollSoftware.Auth.Contracts
{
    internal interface ILoginService
    {
        bool Login(User user);
    }
}