using Management.Core.Models.SchoolManager;
using System.Collections.ObjectModel;

namespace Management.SchoolManagement.Accounts.Contracts
{
    public interface IAccountManager
    {
        ObservableCollection<User> Accounts { get; }
        ObservableCollection<User> GetAccountsByDepartment(long departmentId);
        User? GetAccount(long userId);
    }
}