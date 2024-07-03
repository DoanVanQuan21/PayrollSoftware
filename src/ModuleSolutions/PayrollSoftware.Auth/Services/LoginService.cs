using PayrollSoftware.Auth.Contracts;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.SchoolManager;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;

namespace PayrollSoftware.Auth.Services
{
    internal class LoginService : ILoginService
    {
        private readonly ISchoolManagerServer _dbContext;
        private readonly IAppManager _appManager;
        public LoginService()
        {
            _dbContext = Ioc.Resolve<ISchoolManagerServer>();
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public bool Login(User user)
        {
            var userDb = _dbContext.UserRepository.Login(user);
            if (userDb == null)
            {
                return false;
            }
            _appManager.BootSetting.CurrentUser = userDb;
            return true;
        }
    }
}