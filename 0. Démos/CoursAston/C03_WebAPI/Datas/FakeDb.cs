using C03_WebAPI.Models;

namespace C03_WebAPI.Datas
{
    public class FakeDb
    {
        private List<Dog> _dogs { get; set; }

        public FakeDb()
        {
            _dogs = new();
        }

        public List<Dog> GetAllDogs()
        {
            return _dogs;
        }

        public Dog GetDogById(int id)
        {
            return _dogs.FirstOrDefault(x => x.Id == id);
        }

        public Dog AddDog(Dog newDog)
        {
            _dogs.Add(newDog);

            return newDog;
        }

        public bool RemoveDog(int id)
        {
            Dog found = GetDogById(id);

            if (found == null) return false;

            return _dogs.Remove(found);
        }

        public Dog EditDog(int id, Dog newDog)
        {
            Dog found = GetDogById(id);

            if (found == null) return null;
            else
            {
                found.Name = newDog.Name;
                found.NbOfLegs = newDog.NbOfLegs;
                found.CollarColor = newDog.CollarColor;
                found.Master = newDog.Master;

                return found;
            }
        }
    }
}
