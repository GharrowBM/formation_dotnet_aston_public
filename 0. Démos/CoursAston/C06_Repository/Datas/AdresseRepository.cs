using C05_EFCore.Models;

namespace C05_EFCore.Datas
{
    public class AdresseRepository : BaseRepository, IRepository<Adress>
    {
        public AdresseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Adress Add(Adress entity)
        {
            _context.Adresses.Add(entity);

            _context.SaveChanges();

            return _context.Adresses.FirstOrDefault(x => x == entity);
        }

        public Adress AddOrUpdate(Adress entity)
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
            Adress found = GetById(id);

            if (found != null)
            {
                _context.Adresses.Remove(found);
            }

            return (_context.SaveChanges() > 0);
        }

        public IEnumerable<Adress> GetAll()
        {
            return _context.Adresses;
        }

        public Adress GetById(int id)
        {
            return _context.Adresses.FirstOrDefault(x => x.Id == id);
        }

        public Adress Update(Adress entity)
        {
            Adress found = GetById(entity.Id);

            if (found != null)
            {
                found.StreetNumber = entity.StreetNumber;
                found.StreetName = entity.StreetName;
                found.PostalCode = entity.PostalCode;
                found.CityName = entity.CityName;

                _context.Adresses.Update(found);

                _context.SaveChanges();
            }

            return GetById(entity.Id);
        }
    }
}
