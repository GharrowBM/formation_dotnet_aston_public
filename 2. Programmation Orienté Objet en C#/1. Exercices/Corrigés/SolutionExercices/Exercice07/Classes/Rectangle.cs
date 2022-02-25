using Exercice07.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07.Classes
{
    internal class Rectangle : Figure
    {
        private double _longueur;
        private double _largeur;
        public Rectangle(double x, double y, double longueur, double largeur) : base(x, y)
        {
            _longueur = longueur;
            _largeur = largeur;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Le rectangle a pour centre : ({_coordonnees.X};{_coordonnees.Y})");
            Console.WriteLine($"Le point A a pour coordonnées : ({_coordonnees.X - _longueur / 2};{_coordonnees.Y + _largeur / 2})");
            Console.WriteLine($"Le point B a pour coordonnées : ({_coordonnees.X + _longueur / 2};{_coordonnees.Y + _largeur / 2})");
            Console.WriteLine($"Le point C a pour coordonnées : ({_coordonnees.X + _longueur / 2};{_coordonnees.Y - _largeur / 2})");
            Console.WriteLine($"Le point D a pour coordonnées : ({_coordonnees.X - _longueur / 2};{_coordonnees.Y - _largeur / 2})");
        }
    }
}
