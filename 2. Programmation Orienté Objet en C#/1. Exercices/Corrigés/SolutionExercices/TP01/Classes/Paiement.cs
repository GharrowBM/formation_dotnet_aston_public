using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class Paiement
    {
        protected int _reference;
        protected DateTime _date;

        public int compteurPaiements;

        public int Reference { get => _reference; set => _reference = value; }
        public DateTime Date { get => _date; set => _date = value; }

        public Paiement()
        {
            _reference = ++compteurPaiements;
            _date = DateTime.Now;
        }

        public virtual bool Payer(Vente vente)
        {
            if (vente.Produits.Count > 0)
            {
                double montant = 0;

                foreach (Produit produit in vente.Produits)
                {
                    montant += produit.Price;
                }

                vente.Statut = true;
                Console.WriteLine($"Vous payez {montant} Euros");
                return true;
            }
            else
            {
                Console.WriteLine("Vous n'avez rien à payer");
            }

            return false;

        }
    }
}
