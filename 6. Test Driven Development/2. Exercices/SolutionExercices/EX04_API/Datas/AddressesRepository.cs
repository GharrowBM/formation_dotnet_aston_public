using EX04_API.Models;

namespace EX04_API.Datas
{
    public class AddressesRepository : BaseRepository, IRepository<Address>
    {
        public AddressesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Address Add(Address entity)
        {
            _context.Addresses.Add(entity);

            if (_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            Address found = GetById(id);
            if (found == null) return false;
            _context.Addresses.Remove(found);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToArray();
        }

        public Address GetById(int id)
        {
            var found = _context.Addresses.FirstOrDefault(x => x.Id == id);
            return found;
        }

        public Address Update(int id, Address entity)
        {
            Address found = GetById(id);
            if (found == null) return null;

            found.StreetNumber = entity.StreetNumber;
            found.StreetName = entity.StreetName;
            found.PostalCode = entity.PostalCode;
            found.CityName = entity.CityName;
            _context.Addresses.Update(found);

            if(_context.SaveChanges() > 0) return GetById(entity.Id);
            return null;
        }
    }
}
