using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class Chambre
    {
        private int _id;
        private bool _statut;
        private double _prix;
        private int _capacite;

        public static int compteurChambres;
        public int Id { get => _id; set => _id = value; }
        public bool Statut { get => _statut; set => _statut = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public int Capacite { get => _capacite; set => _capacite = value; }

        public Chambre(double prix, int capacite)
        {
            _id = ++compteurChambres;
            _statut = false;
            _prix = prix;
            _capacite = capacite;
        }
    }
}
