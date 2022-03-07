using C03_WebAPI.Models;

namespace C03_WebAPI.Datas
{
    public class FakeDb
    {
        private List<Dog> _dogs;

        public FakeDb()
        {
            _dogs = new();
        }

        public List<Dog> GetAll()
        {
            return _dogs;
        }

        public Dog GetById(int id)
        {
            return _dogs.FirstOrDefault(x => x.Id == id);
        }

        public Dog AddDog(Dog dog)
        {
            _dogs.Add(dog);
            return dog;
        }

        public bool DeleteDog(int id)
        {
            Dog toDelete = GetById(id);

            if (toDelete == null) return false;

            return _dogs.Remove(toDelete);
        }

        public Dog EditDog(int id, Dog newDog)
        {
            var toEdit = GetById(id);

            if (toEdit == null) return null;

            toEdit.Name = newDog.Name;
            toEdit.NbOfLegs = newDog.NbOfLegs;
            toEdit.CollarColor = newDog.CollarColor;

            return toEdit;
        }
    }
}
