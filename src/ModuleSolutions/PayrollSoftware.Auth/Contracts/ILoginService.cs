using PayrollSoftware.Core.Models.TaskManagement;

namespace PayrollSoftware.Auth.Contracts
{
    internal interface ILoginService
    {
        Task<bool> LoginAsync(User user);
    }
}