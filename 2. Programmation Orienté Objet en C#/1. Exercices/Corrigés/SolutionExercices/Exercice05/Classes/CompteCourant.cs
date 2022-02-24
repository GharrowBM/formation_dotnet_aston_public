using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class CompteCourant : CompteBancaire
    {
        public CompteCourant(Client client) : base(client)
        {
        }

        public CompteCourant(Client client, decimal soldeInitial) : base(client, soldeInitial)
        {
        }
    }
}
