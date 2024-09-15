using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.Core.Mvvms;
using InnoSoft.EntityFramework.Contracts;
using InnoSoft.EntityFramework.Repositories;
using InnoSoft.EntityFramework.Repositories.TaskManagements;

namespace InnoSoft.EntityFramework.Context
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