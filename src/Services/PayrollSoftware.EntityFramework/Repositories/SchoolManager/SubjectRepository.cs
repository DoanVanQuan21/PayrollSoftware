using PayrollSoftware.Core.Models.SchoolManager;
using PayrollSoftware.EntityFramework.Repositories;

namespace PayrollSoftware.EntityFramework.Repositories.SchoolManager
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(SchoolManagerContext context) : base(context)
        {
        }

        public override Subject? GetByCode(string code)
        {
            return _context.Subjects.FirstOrDefault(item => item.SubjectCode == code);
        }

        public override Subject? GetById(int id)
        {
            return _context.Subjects.FirstOrDefault(item => item.SubjectId == id);
        }
    }
}