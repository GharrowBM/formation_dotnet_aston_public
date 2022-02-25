using Exercice07.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07.Classes
{
    internal class Triangle : Figure
    {
        private double _longueur;
        private double _hauteur;
        public Triangle(double x, double y, double longueur, double hauteur) : base(x, y)
        {
            _longueur = longueur;
            _hauteur = hauteur;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Le triangle a pour centre : ({_coordonnees.X};{_coordonnees.Y})");
            Console.WriteLine($"Le point A a pour coordonnées : ({_coordonnees.X - _longueur / 2};{_coordonnees.Y - _hauteur/ 2})");
            Console.WriteLine($"Le point B a pour coordonnées : ({_coordonnees.X};{_coordonnees.Y + _hauteur / 2})");
            Console.WriteLine($"Le point C a pour coordonnées : ({_coordonnees.X + _longueur / 2};{_coordonnees.Y - _hauteur / 2})");
        }
    }
}
