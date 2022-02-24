using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Classes
{
    internal class Triangle : Figure
    {
        private double _longueur;
        private double _hauteur;
        public Triangle(double posX, double posY, double longueur, double hauteur) : base(posX, posY)
        {
            _longueur = longueur;
            _hauteur = hauteur;
        }

        public override void Affiche()
        {
            Console.WriteLine("Coordonnées du triangle ABC :");
            Console.WriteLine($"A = {_posX - _longueur / 2};{_posY - _hauteur / 2}");
            Console.WriteLine($"B = {_posX + _longueur / 2};{_posY - _hauteur / 2}");
            Console.WriteLine($"C = {_posX};{_posY + _hauteur / 2}");
        }
    }
}
