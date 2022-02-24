using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal class IHM
    {
        public void Demarrer()
        {
            Voiture laguna = new Voiture("Renault", "Laguna", 30);

            Console.WriteLine(laguna);
            laguna.Demarrer();
            laguna.Rouler(25);
            Console.WriteLine(laguna);
        }
    }
}
