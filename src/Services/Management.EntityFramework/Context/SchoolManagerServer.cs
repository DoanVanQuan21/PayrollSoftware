using Management.Core.Contracts;
using Management.Core.Models.SchoolManager;
using Management.Core.Mvvms;
using Management.EntityFramework.Contracts;
using Management.EntityFramework.Repositories.SchoolManager;

namespace Management.EntityFramework.Context
{
    public class SchoolManagerServer : ISchoolManagerServer
    {
        private readonly IAppManager _appManager;
        private readonly SchoolManagerContext context;

        public SchoolManagerServer()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            context = new(_appManager.BootSetting.CurrentServerInfor.ConnectionString);
            UserRepository = new(context);
        }

        public UserRepository UserRepository { get; private set; }
    }
}