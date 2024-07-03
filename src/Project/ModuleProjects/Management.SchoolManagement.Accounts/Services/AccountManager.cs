using Management.Core.Models.SchoolManager;
using Management.Core.Mvvms;
using Management.EntityFramework.Contracts;
using Management.SchoolManagement.Accounts.Contracts;
using System.Collections.ObjectModel;
using System.Linq;

namespace Management.SchoolManagement.Accounts.Services
{
    public class AccountManager : IAccountManager
    {
        private readonly ISchoolManagerServer _schoolManagerServer;

        public AccountManager()
        {
            _schoolManagerServer = Ioc.Resolve<ISchoolManagerServer>();
        }

        public ObservableCollection<User> Accounts { get => _schoolManagerServer.UserRepository.GetAll(); }

        public User? GetAccount(long userId)
        {
            return Accounts.FirstOrDefault(item=>item.UserId == userId);
        }

        public ObservableCollection<User> GetAccountsByDepartment(long departmentId)
        {
            return new(Accounts.Where(item => item.DepartmentId == departmentId).ToList());
        }
    }
}