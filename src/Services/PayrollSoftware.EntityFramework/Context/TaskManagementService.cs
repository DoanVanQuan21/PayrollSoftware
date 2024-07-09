using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.EntityFramework.Repositories;
using PayrollSoftware.EntityFramework.Repositories.SchoolManager;
using PayrollSoftware.EntityFramework.Repositories.TaskManagements;

namespace PayrollSoftware.EntityFramework.Context
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly IAppManager _appManager;
        private readonly TaskManagementContext context;

        public TaskManagementService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            context = new(_appManager.BootSetting.CurrentServerInfor.ConnectionString);
            UserRepository = new(context);
            ProjectRepository = new(context);
            TaskRepository = new(context);
        }

        public UserRepository UserRepository { get; private set; }

        public ProjectRepository ProjectRepository { get; private set; }
        public TaskRepository TaskRepository { get; private set; }
    }
}