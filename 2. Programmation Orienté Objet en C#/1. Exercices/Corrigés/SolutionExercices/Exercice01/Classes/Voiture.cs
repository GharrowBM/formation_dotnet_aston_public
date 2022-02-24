using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal class Voiture : VehiculeAMoteur
    {
        public Voiture(string marque, string modele, double volumeMoteur) : base(marque, modele, volumeMoteur)
        {
        }

        public void Rouler(double volume)
        {
            if (!_moteurV.Demarre) _moteurV.Demarrer();
            _moteurV.Utiliser(volume);
        }

        public override string ToString()
        {
            return $"{_marque} {_modele} : {_moteurV.VolumeReservoir}/{_moteurV.VolumeTotal}";
        }
    }
}
