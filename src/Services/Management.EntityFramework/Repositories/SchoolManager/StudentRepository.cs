using Management.Core.Models.SchoolManager;

namespace Management.EntityFramework.Repositories.SchoolManager
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(SchoolManagerContext context) : base(context)
        {
        }

        public override Student? GetByCode(string code)
        {
            return _context.Students.FirstOrDefault(item => item.StudentCode == code);
        }

        public override Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(item => item.StudentId == id);
        }
    }
}