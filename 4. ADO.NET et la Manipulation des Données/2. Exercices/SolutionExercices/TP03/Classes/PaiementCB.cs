using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Interfaces;

namespace TP03.Classes
{
    internal class PaiementCB : IPaiement
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }
        public DateTime DatePaiement { get; set; }
        public PaiementCB()
        {
            Id = ++Compteur;
            DatePaiement = DateTime.Now;
        }


        public bool Payer(decimal montant)
        {
            if (montant > 0 && montant <= 500)
            {
                return true;
            }

            return false;

        }

        public override string ToString()
        {
            return "CB";
        }
    }
}
