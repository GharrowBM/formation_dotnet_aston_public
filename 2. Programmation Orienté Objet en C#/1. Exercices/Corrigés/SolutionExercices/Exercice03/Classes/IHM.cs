using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3.Classes
{
    internal class IHM
    {
        private Pile<string> _pile;

        public IHM(int taillePile)
        {
            _pile = new Pile<string>(taillePile);
        }

        public void Demarrer()
        {

            int choix = -1;
            int indice = 0;

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");
                Console.WriteLine("1. Empiler");
                Console.WriteLine("2. Dépiler");
                Console.WriteLine("3. Récupérer à X");
                Console.WriteLine("0. Quitter");

                Console.Write("Votre choix : ");
                choix = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (choix)
                {
                    case 1:
                        Empiler();
                        break;
                    case 2:
                        Depiler();
                        break;
                    case 3:
                        ChercherAX();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }

                Console.WriteLine("");

            } while (choix != 0);
        }

        private void Empiler()
        {
            Console.Write("Valeur à empiler : ");
            string valeurAEmpiler = Console.ReadLine();
            if (_pile.Empiler(valeurAEmpiler) != null) Console.WriteLine($"{valeurAEmpiler} a été ajoutée à la pile !");
        }

        private void Depiler()
        {
            string valeurDepilee = _pile.Depiler();
            if (valeurDepilee != null ) Console.WriteLine($"{valeurDepilee} a été retirée de la pile");
        }

        private void ChercherAX()
        {
            Console.Write("Veuilliez donner un indice :");
            int indice = int.Parse(Console.ReadLine());
            string valeurAX = _pile.RecupererA(indice);
            if (valeurAX != null ) Console.WriteLine($"La valeur trouvée à l'indice {indice} est : {valeurAX}");

        }
    }
}
