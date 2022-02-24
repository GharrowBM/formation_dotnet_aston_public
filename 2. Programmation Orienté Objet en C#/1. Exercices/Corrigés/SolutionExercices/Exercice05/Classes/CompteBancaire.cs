using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal abstract class CompteBancaire
    {
        protected int _id;
        protected decimal _solde;
        protected Client _client;
        protected List<Operation> _operations;
        public static int NombreComptes = 1;

        public int Id { get => _id; }
        public decimal Solde { get => _solde; set => _solde = value; }
        public Client Client { get => _client; }
        public List<Operation> Operations { get => _operations; }

        public CompteBancaire(Client client)
        {
            _id = NombreComptes++;
            _client = client;
            _solde = 0;
            _operations = new List<Operation>();
        }

        public CompteBancaire(Client client, decimal soldeInitial)
        {
            _id = NombreComptes++;
            _client = client;
            _solde = soldeInitial;
            _operations = new List<Operation>();
        }

        public virtual void FaireUnDepot(decimal montant)
        {
            _operations.Add(new Operation(_operations.Count + 1, montant));
            Solde += montant;
        }

        public virtual void FaireUnRetrait(decimal montant)
        {
            _operations.Add(new Operation(_operations.Count + 1, -montant));
            Solde -= montant;
        }

        public override string ToString()
        {
            return $"{Id}. Propriétaire : {Client} || Solde : {Math.Round(Solde, 2)} Euros";
        }
    }
}
