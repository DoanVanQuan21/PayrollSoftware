using Management.Core.Models.SchoolManager;

namespace Management.Auth.Contracts
{
    internal interface ILoginService
    {
        bool Login(User user);
    }
}