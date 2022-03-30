using EX04_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EX04_API.Datas
{
    public class MastersRepository : BaseRepository, IRepository<Master>
    {
        public MastersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Master Add(Master entity)
        {
            _context.Masters.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            Master found = GetById(id);
            if (found == null) return false;
            _context.Masters.Remove(found);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Master> GetAll()
        {
            return _context.Masters.Include(x => x.Address).ToArray();
        }

        public Master GetById(int id)
        {
            return _context.Masters.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
        }

        public Master Update(int id, Master entity)
        {
            Master found = GetById(id);
            if (found == null) return null;

            found.FirstName = entity.FirstName;
            found.LastName = entity.LastName;
            found.Phone = entity.Phone;
            found.Email = entity.Email;
            found.AddressId = entity.AddressId;
            _context.Masters.Update(found);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
