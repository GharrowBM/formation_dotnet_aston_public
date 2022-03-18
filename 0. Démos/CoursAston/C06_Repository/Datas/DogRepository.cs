using C05_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace C05_EFCore.Datas
{
    public class DogRepository : BaseRepository, IRepository<Dog>
    {
        public DogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Dog Add(Dog entity)
        {
            _context.Dogs.Add(entity);

            _context.SaveChanges();

            return _context.Dogs
                .Include(x => x.Master).ThenInclude(x => x.Adress)
                .FirstOrDefault(x => x == entity);
        }

        public Dog AddOrUpdate(Dog entity)
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
            _context.Dogs.Remove(GetById(id));

            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<Dog> GetAll()
        {
            return _context.Dogs.Include(x => x.Master).ThenInclude(x => x.Adress);
        }

        public Dog GetById(int id)
        {
            return _context.Dogs
                .Include(x => x.Master).ThenInclude(x => x.Adress)
                .FirstOrDefault(x => x.Id == id);
        }

        public Dog Update(Dog entity)
        {
            Dog found = GetById(entity.Id);

            if (found != null)
            {
                found.Name = entity.Name;
                found.Age = entity.Age;
                found.MasterId = entity.MasterId;
                found.CollarColor = entity.CollarColor;

                _context.Dogs.Update(found);

                _context.SaveChanges();
            }

            return GetById(entity.Id);
        }
    }
}
