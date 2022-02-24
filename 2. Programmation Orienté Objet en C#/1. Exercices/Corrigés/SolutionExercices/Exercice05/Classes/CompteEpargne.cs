using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class CompteEpargne : CompteBancaire
    {
        private int _tauxInterets;

        public int TauxInterets { get { return _tauxInterets; } }
        public CompteEpargne(Client client, int tauxInterets) : base(client)
        {
            _tauxInterets = tauxInterets;
        }

        public CompteEpargne(Client client, decimal soldeInitial, int tauxInterets) : base(client, soldeInitial)
        {
            _tauxInterets = tauxInterets;
        }

        public void CalculerInterets()
        {
            Solde = Solde + (Solde * ((decimal) _tauxInterets / 100));
        }
    }
}
