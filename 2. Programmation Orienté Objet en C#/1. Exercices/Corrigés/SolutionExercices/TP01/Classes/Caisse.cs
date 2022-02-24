using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class Caisse
    {
        private List<Produit> _produits;
        private List<Vente> _ventes;

        public List<Produit> Produits { get => _produits; set => _produits = value; }
        public List<Vente> Ventes { get => _ventes; set => _ventes = value; }

        public Caisse()
        {
            _ventes = new List<Vente>();
            _produits = new List<Produit>();
        }
    }
}
