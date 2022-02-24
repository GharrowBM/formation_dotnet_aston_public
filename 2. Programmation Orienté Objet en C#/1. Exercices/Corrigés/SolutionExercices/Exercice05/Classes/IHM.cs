using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class IHM
    {
        private List<CompteBancaire> _compteBancaires;

        public IHM()
        {
            _compteBancaires = new List<CompteBancaire>();
        }

        public void Demarrer()
        {
            int choixMenu = -1;

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");

                Console.WriteLine("1. Lister les comptes bancaires");
                Console.WriteLine("2. Créer un compte bancaire");
                Console.WriteLine("3. Effectuer un dépot");
                Console.WriteLine("4. Effectuer un retrait");
                Console.WriteLine("5. Afficher les opérations et le solde");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Votre choix : ");
                choixMenu = int.Parse(Console.ReadLine());

                switch (choixMenu)
                {
                    case 1:
                        ListerComptes();
                        break;
                    case 2:
                        CreerNouveauCompte();
                        break;
                    case 3:
                        EffectuerDepot();
                        break;
                    case 4:
                        EffectuerRetrait();
                        break;
                    case 5:
                        AfficherOperationEtSolde();
                        break;
                    case 0:
                            break;
                    default:
                        Console.WriteLine("Ce choix n'est pas disponible");
                        break;
                }

                Console.WriteLine("");

            } while (choixMenu != 0);
        }

        private void ListerComptes()
        {
            Console.WriteLine("=== Liste des comptes ===\n");
            foreach (CompteBancaire compte in _compteBancaires) Console.WriteLine(compte);
        }

        private void CreerNouveauCompte()
        {
            int choixTypeCompte = -1;

            do
            {
                Console.WriteLine("=== Création de Compte ===\n");

                Console.WriteLine("1. Créer un compte courant");
                Console.WriteLine("2. Créer un compte épargne");
                Console.WriteLine("3. Créer un compte payant");
                Console.WriteLine("0. Annuler la création de compte");

                Console.Write("Votre choix : ");
                choixTypeCompte = int.Parse(Console.ReadLine());

                switch (choixTypeCompte)
                {
                    case 0:
                        break;
                    case 1:
                        CreerCompteCourant();
                        break;
                    case 2:
                        CreerCompteEpargne();
                        break;
                    case 3:
                        CreerComptePayant();
                        break;
                    default:
                        Console.WriteLine("Ce choix n'est pas disponible");
                        break;
                }

            } while (choixTypeCompte != 0);
        }

        private void CreerCompteCourant()
        {
            Console.Write("Quel est le nom du propriétaire du compte ? ");
            string nomProprietaire = Console.ReadLine();
            Console.Write("Quel est le prénom du propriétaire du compte ? ");
            string prenomProprietaire = Console.ReadLine();
            Console.Write("Quel est le numéro de téléphone du propriétaire du compte ? ");
            string telephoneProprietaire = Console.ReadLine();

            CompteCourant nouveauCompte;

            Console.Write("Ce compte a-t-il un solde initial ? Y/n");
            char choixSoldeInitial = Console.ReadLine().ToLower()[0];
            if (choixSoldeInitial == 'y')
            {
                Console.Write("Quel est le montant initial du compte ? ");
                decimal montantInitial = decimal.Parse(Console.ReadLine());

                nouveauCompte = new CompteCourant(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire), montantInitial);
            }
            else
            {
                nouveauCompte = new CompteCourant(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire));
            }

            _compteBancaires.Add(nouveauCompte);
            Console.WriteLine($"Compte courant créé avec succès ! ID : {nouveauCompte.Id}");
        }

        private void CreerCompteEpargne()
        {

            Console.Write("Quel est le nom du propriétaire du compte ? ");
            string nomProprietaire = Console.ReadLine();
            Console.Write("Quel est le prénom du propriétaire du compte ? ");
            string prenomProprietaire = Console.ReadLine();
            Console.Write("Quel est le numéro de téléphone du propriétaire du compte ? ");
            string telephoneProprietaire = Console.ReadLine();
            Console.Write("Quel est le taux d'intérêts du compte ? ");
            int tauxInterets = int.Parse(Console.ReadLine());

            CompteEpargne nouveauCompte;

            Console.Write("Ce compte a-t-il un solde initial ? Y/n");
            char choixSoldeInitial = Console.ReadLine().ToLower()[0];
            if (choixSoldeInitial == 'y')
            {
                Console.Write("Quel est le montant initial du compte ? ");
                decimal montantInitial = decimal.Parse(Console.ReadLine());

                nouveauCompte = new CompteEpargne(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire), montantInitial, tauxInterets);
            }
            else
            {
                nouveauCompte = new CompteEpargne(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire), tauxInterets);
            }

            _compteBancaires.Add(nouveauCompte);
            Console.WriteLine($"Compte épargne créé avec succès ! ID : {nouveauCompte.Id}");
        }

        private void CreerComptePayant()
        {

            Console.Write("Quel est le nom du propriétaire du compte ? ");
            string nomProprietaire = Console.ReadLine();
            Console.Write("Quel est le prénom du propriétaire du compte ? ");
            string prenomProprietaire = Console.ReadLine();
            Console.Write("Quel est le numéro de téléphone du propriétaire du compte ? ");
            string telephoneProprietaire = Console.ReadLine();

            ComptePayant nouveauCompte;

            Console.Write("Ce compte a-t-il un solde initial ? Y/n");
            char choixSoldeInitial = Console.ReadLine().ToLower()[0];
            if (choixSoldeInitial == 'y')
            {
                Console.Write("Quel est le montant initial du compte ? ");
                decimal montantInitial = decimal.Parse(Console.ReadLine());

                nouveauCompte = new ComptePayant(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire), montantInitial);
            }
            else
            {
                nouveauCompte = new ComptePayant(new Client(nomProprietaire, prenomProprietaire, telephoneProprietaire));
            }

            _compteBancaires.Add(nouveauCompte);
            Console.WriteLine($"Compte payant créé avec succès. ID : {nouveauCompte.Id}");
        }

        private void EffectuerDepot()
        {
            Console.Write("Sur quel compte souhaitez vous effectuer un dépôt ? Donnez son ID : ");
            int idPourDepot = int.Parse(Console.ReadLine());
            
            CompteBancaire compteTrouve = _compteBancaires.Find(c => c.Id == idPourDepot);

            if (compteTrouve != null)
            {
                Console.Write("Quel est le montant du dépôt ? ");
                decimal montantDepot = decimal.Parse(Console.ReadLine());

                compteTrouve.FaireUnDepot(montantDepot);

                Console.WriteLine($"Dépôt effectué avec succès. Nouveau solde : {Math.Round(compteTrouve.Solde, 2)} Euros");
            }
            else Console.WriteLine("Aucun compte avec cet ID trouvé ! Etes-vous sur de ne pas avoir fait une erreur ?");
        }

        private void EffectuerRetrait()
        {
            Console.Write("Sur quel compte souhaitez vous effectuer un retrait ? Donnez son ID : ");
            int idPourRetrait = int.Parse(Console.ReadLine());

            CompteBancaire compteTrouve = _compteBancaires.Find(c => c.Id == idPourRetrait);

            if (compteTrouve != null)
            {
                Console.Write("Quel est le montant du retrait ? ");
                decimal montantRetrait = decimal.Parse(Console.ReadLine());

                compteTrouve.FaireUnRetrait(montantRetrait);

                Console.WriteLine($"Retrait effectué avec succès. Nouveau solde : {Math.Round(compteTrouve.Solde, 2)} Euros");
            }
            else Console.WriteLine("Aucun compte avec cet ID trouvé ! Etes-vous sur de ne pas avoir fait une erreur ?");
        }

        private void AfficherOperationEtSolde()
        {
            Console.Write("Quel compte souhaitez-vous consulter ? Donnez son ID : ");
            int idPourConsultation = int.Parse(Console.ReadLine());

            CompteBancaire compteTrouve = _compteBancaires.Find(c => c.Id == idPourConsultation);

            if (compteTrouve != null)
            {
                Console.WriteLine(compteTrouve);
                Console.WriteLine("Opération du compte : ");
                foreach (Operation operation in compteTrouve.Operations) Console.WriteLine(operation);
            }
            else Console.WriteLine("Aucun compte avec cet ID trouvé ! Etes-vous sur de ne pas avoir fait une erreur ?");
        }
    }
}
