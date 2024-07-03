using Management.EntityFramework.Repositories.SchoolManager;

namespace Management.EntityFramework.Contracts
{
    public interface ISchoolManagerServer
    {
        UserRepository UserRepository { get; }
    }
}