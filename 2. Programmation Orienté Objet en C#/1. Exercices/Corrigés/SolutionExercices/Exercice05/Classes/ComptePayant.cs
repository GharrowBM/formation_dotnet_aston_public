using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class ComptePayant : CompteBancaire
    {
        public ComptePayant(Client client) : base(client)
        {
        }

        public ComptePayant(Client client, decimal soldeInitial) : base(client, soldeInitial)
        {
        }

        public override void FaireUnDepot(decimal montant)
        {   
            base.FaireUnDepot(montant);
            Solde -= 2;
        }

        public override void FaireUnRetrait(decimal montant)
        {
            base.FaireUnRetrait(montant);
            Solde -= 2;
        }
    }
}
