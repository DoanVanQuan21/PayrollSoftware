using Management.Core.Models.SchoolManager;
using Management.EntityFramework.Contracts;

namespace Management.EntityFramework.Repositories.SchoolManager
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SchoolManagerContext context) : base(context)
        {
        }

        public override User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(item => item.UserId == id);
        }

        public override User? GetByCode(string code)
        {
            return _context.Users.FirstOrDefault(item => item.UserCode == code);
        }

        public User? Login(User user)
        {
            return _context.Users.FirstOrDefault(item => item.Username == user.Username && item.Password == user.Password);
        }

        public bool Update(User user)
        {
            var userUpdate = _context.Users.FirstOrDefault(item => item.UserId == user.UserId);
            if (userUpdate == null)
            {
                return false;
            }
            userUpdate.Surname = user.Surname;
            userUpdate.Name = user.Name;
            userUpdate.Email = user.Email;
            userUpdate.Address = user.Address;
            userUpdate.PhoneNumber = user.PhoneNumber;
            userUpdate.Cartificate = user.Cartificate;
            userUpdate.Birthday = user.Birthday;
            _context.ChangeTracker.DetectChanges();
            _context.Entry(userUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}