using C07_API.Models;

namespace C07_API.Datas
{
    public class UsersRepository : BaseRepository, IRepository<User>
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User Add(User entity)
        {
            _context.Users.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            _context.Users.Remove(GetById(id));
            if (_context.SaveChanges() > 0) return true;
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User entity)
        {
            User found = GetById(entity.Id);
            if (found != null)
            {
                found.Email = entity.Email;
                found.Password = entity.Password;
                found.IsAdmin = entity.IsAdmin;

                _context.Users.Update(found);
            }

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

    }
}
