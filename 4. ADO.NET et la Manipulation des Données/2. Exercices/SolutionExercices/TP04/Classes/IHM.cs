using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04.DAO;

namespace TP04.Classes
{
    internal class IHM
    {
        private List<Produit> _produits;
        private List<Vente> _ventes;
        private IDbConnection _sqlConnection;
        private IDbTransaction _transaction;
        public IHM(string connectionString)
        {
            _produits = new List<Produit>();
            _ventes = new List<Vente>();
            _sqlConnection = new SqlConnection(connectionString);
        }

        public void Demarrer()
        {
            int choixMenuPrincipal = -1;
            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Voir les produits");
                Console.WriteLine("2. Ajouter un produit");
                Console.WriteLine("3. Faire une vente");
                Console.WriteLine("0. Quitter");

                Console.Write("Votre choix : ");
                choixMenuPrincipal = int.Parse(Console.ReadLine());

                switch (choixMenuPrincipal)
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
                        FaireUneVente();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenuPrincipal != 0);
        }

        private void VoirProduits()
        {
            List<Produit> produits = new ProduitDAO().GetAll(_sqlConnection);

            Console.WriteLine("=== Liste des produits ===\n");

            produits.ForEach(p =>
            {
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price} Euros ({p.Stock} restants)");
            });
        }
        private void AjouterProduit()
        {
            Console.Write("Nom du produit : ");
            string nom = Console.ReadLine();
            Console.Write("Prix du produit : ");
            decimal prix = decimal.Parse(Console.ReadLine());
            Console.Write("Stock initial : ");
            int stock = int.Parse(Console.ReadLine());

            try
            {
                Produit produit = new Produit()
                {
                    Name = nom,
                    Price = prix,
                    Stock = stock
                };

                _produits.Add(produit);

                if (new ProduitDAO().Save(produit, _sqlConnection))
                {
                    Console.WriteLine("Produit ajouté avec succès !");
                }
                else
                {
                    Console.WriteLine("ERREUR : Impossible d'ajouter le produit !");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void FaireUneVente()
        {
            Vente vente = new Vente();

            int choixMenuVente = -1;
            do
            {
                Console.WriteLine("=== Faire une Vente ===\n");

                Console.WriteLine("1. Ajouter un produit à la vente");
                Console.WriteLine("2. Paiement CB");
                Console.WriteLine("3. Paiement Espece");
                Console.WriteLine("4. Afficher produit de la vente");
                Console.WriteLine("0. Retour au menu principal");

                Console.Write("Votre choix : ");
                choixMenuVente = int.Parse(Console.ReadLine());

                switch (choixMenuVente)
                {
                    case 0:
                        break;
                    case 1:
                        AjoutProduitVente(vente);
                        break;
                    case 2:
                        PaiementCB(vente);
                        break;
                    case 3:
                        PaiementEspece(vente);
                        break;
                    case 4:
                        AfficherProduitVente(vente);
                        break;
                }

                Console.WriteLine("");
            } while (choixMenuVente != 0 && !vente.IsComplete);
        }

        private void AjoutProduitVente(Vente vente)
        {
            Console.Write("Merci de saisir l'id du produit : ");
            int produitId = int.Parse(Console.ReadLine());

            Produit produit = new ProduitDAO().GetById(produitId, _sqlConnection);

            if (produit != null)
            {
                vente.Produits.Add(produit);
                vente.Total += produit.Price;

                Console.WriteLine("Produit ajouté à la vente !");
            }
            else
            {
                Console.WriteLine("Aucun produit avec cet ID !");
            }
        }

        private void AfficherProduitVente(Vente vente)
        {
            vente.Produits.ForEach(p =>
            {
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price} Euros");
            });
        }

        private void PaiementCB(Vente vente)
        {
            PaiementCB paiement = new PaiementCB();
            if (paiement.Payer(vente.Total))
            {
                vente.Paiement = paiement;
                _ventes.Add(vente);

                TerminerVente(vente);

                _produits = new ProduitDAO().GetAll(_sqlConnection);

                AfficherProduitVente(vente);
                Console.WriteLine($"\tTotal : {vente.Total} Euros");
            }
            else
            {
                Console.WriteLine("Paiement refusé !");
            }
        }
        private void PaiementEspece(Vente vente)
        {
            PaiementEspece paiement = new PaiementEspece();
            if (paiement.Payer(vente.Total))
            {
                Console.Write("Monnaie : ");
                decimal monnaie = decimal.Parse(Console.ReadLine());
                paiement.Monnaie = monnaie - vente.Total;
                vente.Paiement = paiement;
                _ventes.Add(vente);

                TerminerVente(vente);

                _produits = new ProduitDAO().GetAll(_sqlConnection);

                AfficherProduitVente(vente);
                Console.WriteLine($"\tTotal : {vente.Total} Euros");
                Console.WriteLine($"\tRendu : {paiement.Monnaie} Euros");
            }
            else
            {
                Console.WriteLine("Paiement refusé !");
            }
        }

        private bool TerminerVente(Vente vente)
        {
            List<Produit> produits = new ProduitDAO().GetAll(_sqlConnection);

            _sqlConnection.Open();
            _transaction = (_sqlConnection as SqlConnection).BeginTransaction("Faire une vente");
            try
            {
                vente.IsComplete = new VenteDAO().Save(vente, _sqlConnection, _transaction);
                vente.Produits.ForEach(produit =>
                {
                    Produit produitTrouve = produits.FirstOrDefault(prod => prod.Id == produit.Id);
                    produitTrouve.Stock--;
                    new VenteDAO().SaveVenteProduits(vente, produitTrouve, _sqlConnection, _transaction);
                    new ProduitDAO().Update(produitTrouve, _sqlConnection, _transaction);
                    if (produitTrouve.Stock <= 0) throw new Exception("Pas assez de stock !");
                });

                _transaction.Commit();
                _sqlConnection.Close();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERREUR : Problème lors de la création de la vente ! Tentative de Rollback...");

                try
                {
                    _transaction.Rollback();
                    _sqlConnection.Close();
                    return false;
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("ERREUR : PRoblème de Rollback...");
                    _sqlConnection.Close();
                    return false;
                }

            }
        }
    }
}
