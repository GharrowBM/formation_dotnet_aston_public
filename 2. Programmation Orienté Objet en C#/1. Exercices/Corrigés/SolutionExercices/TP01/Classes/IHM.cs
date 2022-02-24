using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class IHM
    {
        private Caisse _caisse = new Caisse();
        public void Demarrer()
        {
            int choixMenu = -1;

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");

                Console.WriteLine("1. Voir les produits");
                Console.WriteLine("2. Ajouter un produit dans la caisse");
                Console.WriteLine("3. Faire une vente");
                Console.WriteLine("0. Quitter");

                Console.Write("Votre choix : ");
                choixMenu = int.Parse(Console.ReadLine());

                switch (choixMenu)
                {
                    case 0:
                        break;
                    case 1:
                        VoirProduits();
                        break;
                    case 2:
                        AjouterProduit();
                        break;
                    case 3:
                        FaireVente();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenu != 0);
        }

        private void VoirProduits()
        {
            Console.WriteLine("=== Liste des produits ===\n");

            foreach(Produit produit in _caisse.Produits)
            {
                Console.WriteLine($"{produit.Id}. {produit.Nom} : {produit.Price} Euros ({produit.Stock} restants)");
            }
        }

        private void AjouterProduit()
        {
            Console.Write("Quel est le nom du produit ? ");
            string nomProduit = Console.ReadLine();
            Console.Write("Quel est le prix du produit ? ");
            double prixProduit = double.Parse(Console.ReadLine());
            Console.Write("Quel est le stock du produit ? ");
            int stockProduit = int.Parse(Console.ReadLine());

            Produit produitAjoute = new Produit(nomProduit, stockProduit, prixProduit);
            _caisse.Produits.Add(produitAjoute);
            Console.WriteLine("Le produit a été ajouté avec succès !");
        }

        private void FaireVente()
        {
            int choixVente = -1;
            List<Produit> listeProduits = new List<Produit>();

            do
            {
                Console.WriteLine("=== Faire une Vente ===\n");

                Console.WriteLine("1. Ajouter un produit à la vente");
                Console.WriteLine("2. Paiement par carte");
                Console.WriteLine("3. Paiement par espèces");
                Console.WriteLine("0. Annuler");

                Console.Write("Votre choix : ");
                choixVente = int.Parse(Console.ReadLine());

                switch (choixVente)
                {
                    case 0:
                        break;
                    case 1:
                        AjouterPRoduitAVente(listeProduits);
                        break;
                    case 2:
                        if (PaiementCarte(listeProduits)) choixVente = 0;
                        break;
                    case 3:
                        if (PaiementEspeces(listeProduits)) choixVente = 0;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixVente != 0);

        }

        private void AjouterPRoduitAVente(List<Produit> produits)
        {
            Console.Write("Quel est l'ID du produit ? ");
            int produitID = int.Parse(Console.ReadLine());

            Produit produitTrouve = _caisse.Produits.Find(p=>p.Id == produitID);
            if (produitTrouve == null) Console.WriteLine("Il n'y a aucun produit avec cet ID !");
            else
            {
                produits.Add(produitTrouve);
                Console.WriteLine("Produit ajouté à la vente !");
            }

        }

        private bool PaiementCarte(List<Produit> produits)
        {
            Paiement paiementCarte = new Paiement();
            Vente nouvelleVente = new Vente(produits);
            if (nouvelleVente.Valider(_caisse, paiementCarte)) return true;

            return false;
        }

        private bool PaiementEspeces(List<Produit> produits)
        {
            Console.Write("Combien de monnaie ? ");
            double monnaie = double.Parse(Console.ReadLine());
            PaiementEspeces paiementEspece = new PaiementEspeces(monnaie);
            Vente nouvelleVente = new Vente(produits);
            if (nouvelleVente.Valider(_caisse, paiementEspece)) return true;

            return false;
        }
    }
}
