using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Interfaces;

namespace TP03.Classes
{
    internal class PaiementEspece : IPaiement
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }
        public DateTime DatePaiement { get; set; }
        public decimal Monnaie { get; set; }

        public PaiementEspece()
        {
            Id = ++Compteur;
            DatePaiement = DateTime.Now;
        }

        public bool Payer(decimal montant)
        {
            if (montant > 0 && montant <= 100)
            {
                return true;
            }

            return false;

        }

        public override string ToString()
        {
            return "Especes";
        }
    }
}
