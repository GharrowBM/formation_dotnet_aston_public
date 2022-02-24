using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03.Classes
{
    internal class GenerateurDeMot
    {
        private string[] _motDisponibles = new string[] { "Amazon", "eBay", "Fnac", "CDiscount", "LeBonCoin", "AliExpress", "Micromania", "RueDuCommerce", "Darty", "Alibaba", "Wish", "Leclerc", "Carrefour", "Auchan", "Aldi", "Lidl", "EasyCash" };

        public string Generer()
        {
            int nbAleatoire = new Random().Next(_motDisponibles.Length);
            return _motDisponibles[nbAleatoire].ToUpper();
        }
    }
}
