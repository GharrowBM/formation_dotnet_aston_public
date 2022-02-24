using Exercice4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Classes
{
    internal class Rectangle : Figure, IDeformable
    {
        private double _largeur;
        private double _longueur;

        public Rectangle(double posX, double posY, double largeur, double longueur) : base(posX, posY)
        {
            _largeur = largeur;
            _longueur = longueur;
        }

        public override void Affiche()
        {
            Console.WriteLine("Coordonnées du rectangle ABCD : ");
            Console.WriteLine($"A = {_posX - _longueur / 2};{_posY + _largeur / 2}");
            Console.WriteLine($"B = {_posX + _longueur / 2};{_posY + _largeur / 2}");
            Console.WriteLine($"C = {_posX + _longueur / 2};{_posY - _largeur / 2}");
            Console.WriteLine($"D = {_posX - _longueur / 2};{_posY - _largeur / 2}");
        }

        public Figure Deformation(double coefH, double coefV)
        {
            if (coefH * _longueur == coefV * _largeur)
            {
                return new Carre(_posX, _posY, _longueur * coefH);
            }

            return new Rectangle(_posX, _posY, _largeur * coefV, _longueur * coefH);
        }
    }
}
