using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.EntityFramework.Contracts;
using Task = System.Threading.Tasks.Task;

namespace InnoSoft.EntityFramework.Repositories.TaskManagements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TaskManagementContext context) : base(context)
        {
        }

        public Task<User?> Login(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                return _context.Users.FirstOrDefault(item => item.Username == user.Username && item.Password == user.Password);
            });
        }

        public override Task<bool> Update(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                var userUpdate = _context.Users.FirstOrDefault(item => item.UserId == user.UserId);
                if (userUpdate == null)
                {
                    return false;
                }
                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.Email = user.Email;
                userUpdate.Address = user.Address;
                userUpdate.Phone = user.Phone;
                userUpdate.DateOfBirth = user.DateOfBirth;
                base.Update(userUpdate);
                return true;
            });
        }
    }
}