using EX04_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EX04_API.Datas
{
    public class DogsRepository : BaseRepository, IRepository<Dog>
    {
        public DogsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Dog Add(Dog entity)
        {
            _context.Dogs.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            Dog found = GetById(id);
            if (found == null) return false;
            _context.Dogs.Remove(found);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Dog> GetAll()
        {
            return _context.Dogs.Include(x => x.Master).ThenInclude(x => x.Address).ToArray();
        }

        public Dog GetById(int id)
        {
            return _context.Dogs.Include(x => x.Master).ThenInclude(x => x.Address).FirstOrDefault(x => x.Id == id);
        }

        public Dog Update(int id, Dog entity)
        {
            Dog found = GetById(id);
            if (found == null) return null;

            found.Name = entity.Name;
            found.DateOfBirth = entity.DateOfBirth;
            found.CollarColor = entity.CollarColor;
            found.MasterId = entity.MasterId;
            _context.Dogs.Update(found);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
