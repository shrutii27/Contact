using Contact.Data;
using Contact.Model;
using System.Reflection.Metadata.Ecma335;

namespace Contact.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.Where(User => User.IsActive == true)
                .ToList();
        }
        public User GetById(int id)
        {
            return _context.Users.Where(user => user.UserId == id && user.IsActive == true).FirstOrDefault();

        }
        public int Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            var newUserId = _context.Users.Where(user1 => user1.FirstName == user.FirstName)
                .OrderBy(usr => user.UserId).LastOrDefault().UserId;
            return newUserId;
        }
        public User Update(User user)
        {
            var userToUpdate = GetById(user.UserId);
            if (userToUpdate != null)
            {
                _context.Entry(userToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                _context.Users.Update(user);
                _context.SaveChanges();
                return user;

            }
            return null;
        }
        public bool Delete(int id) //soft update
        {
            var userToDelete = GetById(id);
            if (userToDelete != null)
            {
                userToDelete.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

