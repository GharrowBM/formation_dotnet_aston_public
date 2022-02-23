using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public enum GenderPersonne
    {
        Homme,
        Femme
    }
    [Flags]
    public enum FavAnimalsPerson
    {
        Rien = 0,
        Chien = 1,
        Chat = 2,
        Chipmunk = 4,
        Hamster = 8,
        Panther = 16,
        Loup = 32
    }
    public class Personne
    {
        private string _name;
        private GenderPersonne _gender;
        private FavAnimalsPerson _favAnimals;
        public string Name { get => _name; set => _name = value; }
        public GenderPersonne Gender { get => _gender; }
        public FavAnimalsPerson FavAnimals { get => _favAnimals; set => _favAnimals = value; }

        public static Personne operator * (Personne a, Personne b)
        {
            if (a._gender == b._gender) return null;

            Random rng = new();
            int rngAlea = rng.Next(2);

            return new Personne(GenerateurDePrenom.Generer(rngAlea), (GenderPersonne) rngAlea);

        }

        public Personne(string name, GenderPersonne gender)
        {
            _name = name;
            _gender = gender;
        }

        public override string ToString()
        {
            return $"{_name} est un {_gender} et a comme animaux préférés : {_favAnimals}";
        }

    }
}
