using PayrollSoftware.Auth.Contracts;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;

namespace PayrollSoftware.Auth.Services
{
    internal class LoginService : ILoginService
    {
        private readonly ITaskManagementService _dbContext;
        private readonly IAppManager _appManager;

        public LoginService()
        {
            _dbContext = Ioc.Resolve<ITaskManagementService>();
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public async Task<bool> LoginAsync(User user)
        {
            var userDb = await _dbContext.UserRepository.Login(user);
            if (userDb == null)
            {
                return false;
            }
            _appManager.BootSetting.CurrentUser = userDb;
            return true;
        }
    }
}