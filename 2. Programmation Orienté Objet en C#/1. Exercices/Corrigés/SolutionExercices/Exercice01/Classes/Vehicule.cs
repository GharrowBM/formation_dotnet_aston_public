using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal abstract class Vehicule
    {
        protected string _marque;
        protected string _modele;

        public Vehicule(string marque, string modele)
        {
            _marque = marque;
            _modele = modele;
        }

        public abstract bool Demarrer();

        public abstract void Arreter();

        public abstract void FaireLePlein(double volume);
    }
}
