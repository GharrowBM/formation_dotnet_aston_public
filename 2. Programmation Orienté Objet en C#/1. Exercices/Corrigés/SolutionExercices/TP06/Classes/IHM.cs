using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class IHM
    {
        private Hotel _hotel;

        public void Demarrer()
        {
            CreerHotel();

            int choixMenu = -1;

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");

                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Afficher la liste des clients");
                Console.WriteLine("3. Afficher les réservations d'un client");
                Console.WriteLine("4. Ajouter une réservation");
                Console.WriteLine("5. Annuler une réservation");
                Console.WriteLine("6. Afficher la liste des réservations");
                Console.WriteLine("0. Quitter");

                Console.Write("Votre choix : ");
                choixMenu = int.Parse(Console.ReadLine());

                switch(choixMenu)
                {
                    case 0:
                        break;
                    case 1:
                        AjouterClient();
                        break;
                    case 2:
                        AfficherListeClients();
                        break;
                    case 3:
                        AfficherReservationDuClient();
                        break;
                    case 4:
                        AjouterReservation();
                        break;
                    case 5:
                        AnnulerReservation();
                        break;
                    case 6:
                        AfficherListeReservations();
                        break;
                    default:
                        Console.WriteLine("Ce choix n'est pas disponible !");
                        break;
                }

                Console.WriteLine("");

            } while (choixMenu != 0);
        }

        private void CreerHotel()
        {
            Console.WriteLine("=== Création de l'Hôtel ===\n");

            Console.Write("Quel est le nom de l'hôtel ? ");
            string nomHotel = Console.ReadLine();
            _hotel = new Hotel(nomHotel);

            Console.WriteLine($"{_hotel.Nom} créé avec succès !");
        }

        private void AjouterClient()
        {
            Console.WriteLine("=== Ajout d'un client ===\n");

            Console.Write("Quel est le nom du client ? ");
            string nomClient = Console.ReadLine();
            Console.Write("Quel est le prénom du client ? ");
            string prenomClient = Console.ReadLine();
            Console.Write("Quel est le téléphone du client ? ");
            string telClient = Console.ReadLine();

            Client nouveauClient = new Client(nomClient, prenomClient, telClient);
            _hotel.AddClient(nouveauClient);

            Console.WriteLine("Client ajouté avec succès !");

        }

        private void AfficherListeClients()
        {
            Console.WriteLine("=== Liste des clients ===\n");
            
            List<Client> clients = _hotel.GetClients();

            if (clients.Count == 0) Console.WriteLine("Il n'y a encore aucun client dans l'hôtel !");
            else
            {

                foreach (Client client in clients)
                {
                    Console.WriteLine($"Client N°{client.Id}. {client.Prenom} {client.Nom}, Tel : {client.Telephone}");
                }
            }
            
        }

        private void AfficherReservationDuClient()
        {
            Console.WriteLine("=== Réservation d'un client ===\n");

            Console.Write("Quel est le numéro de téléphone à chercher ? ");
            string telephoneAChercher = Console.ReadLine();

            Client clientTrouve = _hotel.Clients.Find(c => c.Telephone == telephoneAChercher);
            if (clientTrouve != null)
            {
                List<Reservation> reservatonsDuClient = _hotel.GetClientReservations(clientTrouve);

                if (reservatonsDuClient.Count == 0) Console.WriteLine("Ce client n'a encore réservé aucune chambre !");
                else
                {

                    foreach (Reservation reservation in reservatonsDuClient)
                    {
                        double prixReservation = 0;

                        Console.WriteLine($"Réservation N°{reservation.Id}. {(reservation.Statut ? "Validée" : "En cours")} {reservation.Chambres.Count} chambres : ");
                        
                        foreach(Chambre chambre in reservation.Chambres)
                        {
                            Console.WriteLine($"Chambre N°{chambre.Id}. {chambre.Capacite} lits pour {chambre.Prix} Euros");
                            prixReservation += chambre.Prix;
                        }

                        Console.WriteLine($"Valeur totale de la réservation : {prixReservation} Euros\n");

                    }
                }
            }
            else
            {
                Console.WriteLine("Aucun client ne correspond à la recherche !");
            }
        }

        private void AjouterReservation()
        {
            Console.WriteLine("=== Créer une nouvelle réservation ===\n");

            Console.Write("Quel est le numéro de téléphone du client ? ");
            string telephoneClient = Console.ReadLine();

            Client clientReservant = _hotel.Clients.Find(c => c.Telephone == telephoneClient);

            if (clientReservant == null) Console.WriteLine("Aucun client ne possède ce numéro de téléphone...");
            else
            {
                Console.Write("Combien de personnes vont-elles séjourner à l'hôtel ? ");
                int nombrePersonnes = int.Parse(Console.ReadLine());

                int litsAAffecter = nombrePersonnes;
                List<Chambre> chambresAAffecter = new List<Chambre>();
                bool affectationPossible = false;

                foreach (Chambre chambre in _hotel.Chambres)
                {
                    if (!chambre.Statut)
                    {
                        litsAAffecter -= chambre.Capacite;
                        chambresAAffecter.Add(chambre);
                        if (litsAAffecter <= 0)
                        {
                            affectationPossible = true;
                            break;
                        }
                    }
                }

                if (!affectationPossible) Console.WriteLine("Réservation impossible ! Les capacités de l'hôtel ne permettent pas cette réservation...");
                else
                {
                    Reservation nouvelleReservation = new Reservation(clientReservant, chambresAAffecter);
                    foreach (Chambre chambre in chambresAAffecter) chambre.Statut = true;
                    _hotel.AddReservation(nouvelleReservation);
                    Console.WriteLine("Réservation créée avec succès !");
                }

            }

        }

        private void AnnulerReservation()
        {
            Console.WriteLine("=== Annuler une réservation ===\n");

            Console.Write("Quel est le numéro de la réservation à annuler ? ");
            int reservationIDASupprimer = int.Parse(Console.ReadLine());
            
            Reservation reservationTrouvee = _hotel.Reservations.Find(r=>r.Id == reservationIDASupprimer);

            if (reservationTrouvee == null) Console.WriteLine("Aucune réservation trouvée avec cet ID !");
            else
            {
                foreach (Chambre chambre in reservationTrouvee.Chambres) chambre.Statut = false;
                _hotel.DeleteReservation(reservationTrouvee);
                Console.WriteLine("Réservation supprimée avec succès !");
            }
        }

        private void AfficherListeReservations()
        {
            Console.WriteLine("=== Liste des réservations ===\n");

            List<Reservation> reservations = _hotel.GetAllReservations();

            if (reservations.Count == 0) Console.WriteLine("L'hôtel ne possède encore aucune réservation !");
            else
            {

                foreach (Reservation reservation in reservations)
                {
                    double prixReservation = 0;

                    Console.WriteLine($"Réservation N°{reservation.Id}. Réservation de {reservation.Client.Nom} - {(reservation.Statut ? "Validée" : "En cours")} {reservation.Chambres.Count} chambres : ");

                    foreach (Chambre chambre in reservation.Chambres)
                    {
                        Console.WriteLine($"Chambre N°{chambre.Id}. {chambre.Capacite} lits pour {chambre.Prix} Euros");
                        prixReservation += chambre.Prix;
                    }

                    Console.WriteLine($"Valeur totale de la réservation : {prixReservation} Euros\n");

                }
            }
        }
    }
}
