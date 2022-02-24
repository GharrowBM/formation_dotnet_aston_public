using Exercice4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Classes
{
    internal class Carre : Figure, IDeformable
    {
        private double _longueur;
        public Carre(double posX, double posY, double longueur) : base(posX, posY)
        {
            _longueur = longueur;
        }

        public override void Affiche()
        {
            Console.WriteLine("Coordonnées du carré ABCD : ");
            Console.WriteLine($"A = {_posX - _longueur / 2};{_posY + _longueur / 2}");
            Console.WriteLine($"B = {_posX + _longueur / 2};{_posY + _longueur / 2}");
            Console.WriteLine($"C = {_posX + _longueur / 2};{_posY - _longueur / 2}");
            Console.WriteLine($"D = {_posX - _longueur / 2};{_posY - _longueur / 2}");
        }

        public Figure Deformation(double coefH, double coefV)
        {
            if (coefH != coefV)
            {
                return new Rectangle(_posX, _posY, coefV * _longueur, coefH * _longueur);
            }

            return new Carre(_posX, _posY, _longueur * coefH);
        }
    }
}
