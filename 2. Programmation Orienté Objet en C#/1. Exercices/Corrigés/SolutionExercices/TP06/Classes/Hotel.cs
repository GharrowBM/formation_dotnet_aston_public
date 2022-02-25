using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class Hotel
    {
        private string _nom;
        private List<Chambre> _chambres;
        private List<Client> _clients;
        private List<Reservation> _reservations;

        public string Nom { get => _nom; set => _nom = value; }
        internal List<Chambre> Chambres { get => _chambres; set => _chambres = value; }
        internal List<Client> Clients { get => _clients; set => _clients = value; }
        internal List<Reservation> Reservations { get => _reservations; set => _reservations = value; }

        public Hotel(string nom)
        {
            _nom = nom;
            _chambres = new List<Chambre>();
            GenerateRooms();
            _clients = new List<Client>();
            _reservations = new List<Reservation>();
        } 

        private void GenerateRooms()
        {
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                _chambres.Add(new Chambre(random.Next(20, 101), random.Next(1, 7)));
            }
        }

        public bool AddClient(Client client)
        {
            _clients.Add(client);
            return true;
        }
        public List<Client> GetClients()
        {
            return _clients;
        }

        public List<Reservation> GetClientReservations(Client client)
        {
            List<Reservation> reservationduClient = _reservations.FindAll(r => r.Client == client);
            return reservationduClient;
        }

        public bool AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
            return true;
        }

        public bool DeleteReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
            return true;
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservations;
        }

    }
}
