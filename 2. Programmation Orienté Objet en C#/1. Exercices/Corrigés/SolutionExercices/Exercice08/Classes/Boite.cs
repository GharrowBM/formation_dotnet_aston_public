using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice08.Classes
{
    internal class Boite
    {
        private double _hauteur;
        private double _largeur;
        private double _profondeur;

        public Boite(double hauteur, double largeur, double profondeur)
        {
            _hauteur = hauteur;
            _largeur = largeur;
            _profondeur = profondeur;
        }

        public static Boite operator +(Boite a) => a;
        public static Boite operator +(Boite a, Boite b) => new Boite((a._hauteur + b._hauteur), Math.Max(a._largeur, b._largeur), Math.Max(a._profondeur, b._profondeur));
        public static Boite operator *(Boite a, Boite b) => new Boite((a._hauteur + b._hauteur), (a._largeur + b._largeur), (a._profondeur + b._profondeur));

        public override string ToString()
        {
            return $"Surface occupée par la boite => Hauteur : {_hauteur}, Largeur : {_largeur}, Profondeur : {_profondeur}";
        }
    }
}
