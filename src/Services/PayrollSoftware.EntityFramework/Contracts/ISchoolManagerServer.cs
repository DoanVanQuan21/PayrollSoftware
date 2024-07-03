using PayrollSoftware.EntityFramework.Repositories.SchoolManager;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface ISchoolManagerServer
    {
        UserRepository UserRepository { get; }
    }
}