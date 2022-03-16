using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Interfaces;

namespace TP03.Classes
{
    internal class Vente
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }
        public List<Produit> Produits { get; set; }
        public decimal Total { get; set; }
        public IPaiement Paiement { get; set; }
        public bool IsComplete { get; set; }

        public Vente()
        {
            Id = ++Compteur;
            Produits = new List<Produit>();
        }
    }
}
