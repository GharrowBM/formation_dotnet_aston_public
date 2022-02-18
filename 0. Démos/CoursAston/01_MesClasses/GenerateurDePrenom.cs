using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses
{
    public static class GenerateurDePrenom
    {
        private static readonly string[] _boyNames = { "Léo", "Gabriel", "Raphaël", "Arthur", "Louis", "Jules", "Adam",
            "Maël", "Lucas", "Hugo", "Noah", "Liam", "Gabin", "Sacha", "Paul", "Nathan", "Aaron", "Mohamed", "Ethan", "Tom"};

        private static readonly string[] _girlNames = {"Jade", "Louise", "Emma", "Alice", "Ambre", "Lina", "Rose", "Chloé",
            "Mia", "Léa", "Anna", "Mila", "Julia", "Romy", "Lou", "Inès", "Léna", "Agathe", "Juliette", "Inaya"};

        public static string Generer(int gender)
        {

            if (gender == 0) return _boyNames[new Random().Next(_boyNames.Length)];
            else return _girlNames[new Random().Next(_boyNames.Length)];
        }

        public static string RetournerType(IMovable animal)
        {
            return animal.GetType().Name;
        }
    }
}
