using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class Vente
    {
        private int _id;
        private List<Produit> _produits;
        private bool _statut;
        private Paiement _paiement;

        public static int compteur;

        public int Id { get => _id; set => _id = value; }
        public List<Produit> Produits { get => _produits; set => _produits = value; }
        public bool Statut { get => _statut; set => _statut = value; }
        public Paiement Paiement { get => _paiement; set => _paiement = value; }

        public Vente(List<Produit> produits)
        {
            _id = ++compteur;
            _produits = produits;
            _statut = false;
        }

        public bool Valider(Caisse caisse, Paiement paiement)
        {
            List<Produit> tmpList = caisse.Produits;
            bool ventePossible = true;

            foreach(Produit produit in _produits)
            {
                Produit prodAVerif = tmpList.Find(p => p == produit);
                prodAVerif.Stock -= 1;
                if (prodAVerif.Stock < 0) ventePossible = false;
            }

            if (!ventePossible) 
            {
                foreach (Produit produit in _produits) produit.Stock += 1;
                Console.WriteLine("Il n'y a pas assez de stocks dans le magasin pour réaliser cette vente !");
            } 
            else
            {
                if (paiement.Payer(this))
                {
                    _paiement = paiement;

                    Console.WriteLine("Vente terminée !");
                    return true;
                }

            }

            return false;
        }
    }
}
