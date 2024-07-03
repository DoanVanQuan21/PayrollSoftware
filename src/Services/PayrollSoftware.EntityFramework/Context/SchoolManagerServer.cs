using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models.SchoolManager;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.EntityFramework.Repositories.SchoolManager;

namespace PayrollSoftware.EntityFramework.Context
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