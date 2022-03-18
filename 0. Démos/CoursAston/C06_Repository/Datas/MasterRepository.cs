using C05_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace C05_EFCore.Datas
{
    public class MasterRepository : BaseRepository, IRepository<Master>
    {
        public MasterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Master Add(Master entity)
        {
            _context.Masters.Add(entity);

            _context.SaveChanges();
            
            return _context.Masters
                .Include(x => x.Adress)
                .FirstOrDefault(x => x == entity);
        }

        public Master AddOrUpdate(Master entity)
        {
            if (entity.Id == 0)
            {
                return Add(entity);
            }
            else
            {
                return Update(entity);
            }
        }

        public bool Delete(int id)
        {
            Master found = GetById(id);

            if (found != null)
            {
                _context.Masters.Remove(found);
            }

            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<Master> GetAll()
        {
            return _context.Masters.Include(x => x.Adress);
        }

        public Master GetById(int id)
        {
            return _context.Masters
                .Include(x => x.Adress)
                .FirstOrDefault(x => x.Id == id);
        }

        public Master Update(Master entity)
        {
            Master found = GetById(entity.Id);

            if (found != null)
            {
                found.Firstname = entity.Firstname;
                found.Lastname = entity.Lastname;
                found.Email = entity.Email;
                found.Phone = entity.Phone;
                found.AdressId = entity.AdressId;

                _context.Masters.Update(found);

                _context.SaveChanges();
            }

            return GetById(entity.Id);
        }
    }
}
