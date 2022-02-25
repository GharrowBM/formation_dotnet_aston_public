using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal class Person
    {
        private string _name;
        private GenderEnum _gender;

        public Person(string name, int gender)
        {
            _name = name;
            _gender = (GenderEnum) gender;
        }

        /*
         * Il est possible de créer des opérateurs nous mêmes pour s'en servir lors de la manipulation des classes que l'on créé, 
         * 
         * Ici par exemple nous cherchons à reproduire l'accouplement de deux individus et ajoutons de la logique métier pour créer un enfant à partir de ces deux personnes
         * 
         */
        public static Person operator +(Person p) => p;
        public static Person operator +(Person a, Person b)
        {
            if (a._gender == b._gender) return default(Person);
            else 
            {
                Random random = new Random();
                int alea = random.Next(2);
                return new Person(GenerateurNom.Generer(alea), alea);
            }
        }

        public override string ToString()
        {
            return $"{_name} est {((int)_gender == 0 ? "un homme" : "une femme")}";
        }
    }
}
