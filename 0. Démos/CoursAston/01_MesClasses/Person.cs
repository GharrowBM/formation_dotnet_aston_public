namespace MesClasses
{
    public sealed class Person : IMovable
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private DateTime _dateOfBirth;

        //public string FirstName { get => _firstName; set => _firstName = value; }
        //public string LastName { get => _lastName; set => _lastName = value; }
        //public int Age { get => _age; }

        public int AgeCalcule
        {
            get
            {
                return DateTime.Now.Year - _dateOfBirth.Year;
            }
        }

        public Person(string firstname, string lastname)
        {
            _firstName = firstname;
            _lastName = lastname;
        }

        public Person(string firstname, string lastname, int age) : this (firstname, lastname)
        {
            _age = age;
        }

        public Person(string firstname, string lastname, DateTime dateOfBirth) : this (firstname, lastname)
        {
            _dateOfBirth = dateOfBirth;
        }

        public Person()
        {
            _firstName = "Bernard";
            _lastName = "MARTIN";
            _age = 25;
;        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName} a {_age} ans";
        }

        public override bool Equals(object? obj)
        {
            Person objToPerson = (Person) obj;

            return (objToPerson._firstName == this._firstName && objToPerson._lastName == this._lastName);

            //if (objToPerson._firstName == this._firstName && objToPerson._lastName == this._lastName) return true;
            //return false;
        }

        public void MoveForward(double distance)
        {
            Console.WriteLine($"L'humain avance de {distance:N0} mètres avec ses pieds.");
        }

        public void MoveBackward(double distance)
        {
            Console.WriteLine($"L'humain recule de {distance:N0} mètres avec ses pieds.");

        }
    }
}