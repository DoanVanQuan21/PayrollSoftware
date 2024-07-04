using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.EntityFramework.Repositories.SchoolManager;

namespace PayrollSoftware.EntityFramework.Context
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly IAppManager _appManager;
        private readonly TaskManagementContext context;

        public TaskManagementService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            context = new(@$"{_appManager.BootSetting.CurrentServerInfor.ConnectionString}");
            UserRepository = new(context);
        }

        public UserRepository UserRepository { get; private set; }
    }
}