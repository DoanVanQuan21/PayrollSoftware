using InnoSoft.Core.Context;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.Core.Mvvms;
using InnoSoft.Auth.Contracts;
using InnoSoft.EntityFramework.Contracts;

namespace InnoSoft.Auth.Services
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