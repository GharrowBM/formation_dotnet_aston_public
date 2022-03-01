using C02_ASPNet.Models;

namespace C02_ASPNet.Controllers.Services
{
    public class DabaseMock
    {
        private List<string> _list;
        private List<Dog> _dogs;
        private List<Person> _persons;
        public List<string> List { get { return _list; } }
        public List<Dog> Dogs { get { return _dogs; } }
        public List<Person> Persons { get { return _persons; } }
        public DabaseMock()
        {
            _list = new List<string>();
            _dogs = new List<Dog>();
            _persons = new List<Person>();

            SeedDb();
        }

        public bool Add(string addedValue)
        {
            _list.Add(addedValue);

            return true;
        }

        public bool Remove(int id)
        {
            _list.RemoveAt(id);

            return true;
        }

        public bool Edit(int id, string newValue)
        {
            _list[id] = newValue;

            return true;
        }

        public List<string> GetAll()
        {
            return _list;
        }

        private void SeedDb()
        {
            if (!_list.Any())
            {
                _list.Add("Bernie");
                _list.Add("Arnold");
                _list.Add("Chloée");
                _list.Add("John");
            }

            if (!_dogs.Any())
            {
                _dogs.AddRange(new List<Dog>()
                {
                    new Dog() {Name = "Bernie", NbOfLegs = 4, CollarColor = CollarColor.Red},
                    new Dog() {Name = "Saphir", NbOfLegs = 3, CollarColor = CollarColor.Pink},
                    new Dog() {Name = "Rex", NbOfLegs = 4, CollarColor = CollarColor.Black},
                });
            }

            if(!_persons.Any())
            {
                _persons.AddRange(new List<Person>()
                {
                    new Person() {Name ="John SNOW"},
                    new Person() {Name ="Martin LUTHER"},
                    new Person() {Name ="Barrack OBAMA"},
                    new Person() {Name ="Homer SIMPSON"}
                });
            }
        }
    }
}
