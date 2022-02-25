using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class Reservation
    {
        private int _id;
        private bool _statut;
        private Client _client;
        private List<Chambre> _chambres;

        public static int compteurReservations;
        public int Id { get => _id; set => _id = value; }
        public bool Statut { get => _statut; set => _statut = value; }
        internal Client Client { get => _client; set => _client = value; }
        internal List<Chambre> Chambres { get => _chambres; set => _chambres = value; }

        public Reservation(Client client, List<Chambre> chambres)
        {
            _id = ++compteurReservations;
            _statut = false;
            _client = client;
            _chambres = chambres;
        }
    }
}
