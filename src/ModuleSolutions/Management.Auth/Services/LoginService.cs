using Management.Auth.Contracts;
using Management.Core.Context;
using Management.Core.Contracts;
using Management.Core.Models.SchoolManager;
using Management.Core.Mvvms;
using Management.EntityFramework.Contracts;

namespace Management.Auth.Services
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