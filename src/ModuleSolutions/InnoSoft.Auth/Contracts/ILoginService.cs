using InnoSoft.Core.Models.TaskManagement;

namespace InnoSoft.Auth.Contracts
{
    internal interface ILoginService
    {
        Task<bool> LoginAsync(User user);
    }
}