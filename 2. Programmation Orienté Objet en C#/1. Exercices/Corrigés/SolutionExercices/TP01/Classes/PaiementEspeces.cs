using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class PaiementEspeces : Paiement
    {
        private double _monnaie;
        public PaiementEspeces(double monnaie) : base()
        {
            _monnaie = monnaie;
        }

        public override bool Payer(Vente vente)
        {
            if (vente.Produits.Count > 0)
            {
                double montant = 0;

                foreach (Produit produit in vente.Produits)
                {
                    montant += produit.Price;
                }

                if (_monnaie > montant)
                {
                    Console.WriteLine($"Vous payez {montant} Euros, et on vous rend {_monnaie - montant} Euros");
                    vente.Statut = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Vous n'avez pas assez pour payer !");
                }

            }
            else
            {
                Console.WriteLine("Vous n'avez rien à payer");
            }

            return false;
        }
    }
}
