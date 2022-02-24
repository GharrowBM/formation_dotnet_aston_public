using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal abstract class VehiculeAMoteur : Vehicule
    {
        protected Moteur _moteurV;

        protected VehiculeAMoteur(string marque, string modele, double volumeMoteur) : base(marque, modele)
        {
            _moteurV = new Moteur(volumeMoteur);
        }

        public override bool Demarrer()
        {
            return _moteurV.Demarrer();
        }
        public override void Arreter()
        {
            _moteurV.Arreter();
        }

        public override void FaireLePlein(double volume)
        {
            if (_moteurV.Demarre) _moteurV.Arreter();
            _moteurV.FaireLePlein(volume);
            _moteurV.Demarrer();
        }
    }
}
