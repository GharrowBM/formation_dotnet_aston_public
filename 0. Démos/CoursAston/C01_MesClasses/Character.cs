using C01_MesClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class Character
    {
        private string _name;
        private Gender _gender;
        private FavoriteAnimals _favAnimals;

        public string Name { get => _name; set => _name = value; }
        public Gender Gender { get => _gender; }
        public FavoriteAnimals FavAnimals { get => _favAnimals; set => _favAnimals = value; }

        public static Character operator * (Character a, Character b)
        {
            if (a._gender == b._gender) return null;


            Random random = new Random();
            int rngSex = random.Next(2);

            return new Character(rngSex);
        }

        public Character(int rngSex)
        {
            _name = GenerateurDePrenom.Generer(rngSex);
            _gender = (Gender)rngSex;
        }

        public Character(string name, Gender gender)
        {
            _name = name;
            _gender = gender;
        }

        public Character(string name, Gender gender, FavoriteAnimals favAnimals) : this (name, gender)
        {
            _favAnimals = favAnimals;
        }

        public override string ToString()
        {
            return $"{_name} est un {_gender} et ses animaux préférés sont : {_favAnimals}";
        }
    }
}
