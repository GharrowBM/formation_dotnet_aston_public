using Exercice07.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07.Classes
{
    internal class Carre : Figure
    {
        private double _longueur;
        public Carre(double x, double y, double longueur) : base(x, y)
        {
            _longueur = longueur;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Le carré a pour centre : ({_coordonnees.X};{_coordonnees.Y})");
            Console.WriteLine($"Le point A a pour coordonnées : ({_coordonnees.X - _longueur/2};{_coordonnees.Y + _longueur/2})");
            Console.WriteLine($"Le point B a pour coordonnées : ({_coordonnees.X + _longueur/2};{_coordonnees.Y + _longueur/2})");
            Console.WriteLine($"Le point C a pour coordonnées : ({_coordonnees.X + _longueur/2};{_coordonnees.Y - _longueur/2})");
            Console.WriteLine($"Le point D a pour coordonnées : ({_coordonnees.X - _longueur/2};{_coordonnees.Y - _longueur/2})");
        }
    }
}
