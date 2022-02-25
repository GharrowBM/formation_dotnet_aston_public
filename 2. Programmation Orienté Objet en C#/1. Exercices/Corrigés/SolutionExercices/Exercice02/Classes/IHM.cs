using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class IHM
    {
        private Forum _forum;

        public void Demarrer()
        {
            _forum = CreationForum();

            MenuPrincipal();
        }

        private Forum CreationForum()
        {
            Console.WriteLine("=== Premiere étape : Création du Forum ===\n");
            Console.Write("Quel est le nom de ce forum ? ");
            string nomForum = Console.ReadLine();
            Console.Write("Combien d'abonnés ce forum aura-t-il ? ");
            int nbAbonnes = int.Parse(Console.ReadLine());
            Console.Write("Combien de nouvelles ce forum aura-t-il ? ");
            int nbNouvelles = int.Parse(Console.ReadLine());

            _forum = new Forum(nomForum, nbNouvelles, nbAbonnes);
            
            Console.Write("Ce forum aura-t-il un modérateur ? Y/n");
            char choixModo = Console.ReadLine().ToLower()[0];
            if (choixModo == 'y') AffecterModo();

            return _forum;
        }

        private void AffecterModo()
        {
            Console.WriteLine("=== Affectation d'un modérateur au forum ===\n");
            Console.Write("Quel est le nom du modérateur ? ");
            string nomModo = Console.ReadLine();
            Console.Write("Quel est le prénom du modérateur ? ");
            string prenomModo = Console.ReadLine();
            Console.Write("Quel est l'âge du modérateur ? ");
            int ageModo = int.Parse(Console.ReadLine());

            Moderateur modoForum = new Moderateur(prenomModo, nomModo, ageModo, _forum);
            _forum.Moderateur = modoForum;
        }

        private void MenuPrincipal()
        {
            int choixMenu = -1;

            do
            {
                Console.WriteLine("=== Menu Principal ===\n");

                Console.WriteLine("1. Voir les abonnés");
                Console.WriteLine("2. Ajouter un abonné");
                Console.WriteLine("3. Bannir un abonné");
                Console.WriteLine("4. Voir les nouvelles");
                Console.WriteLine("5. Consulter une nouvelle");
                Console.WriteLine("6. Ajouter une nouvelle");
                Console.WriteLine("7. Répondre à une nouvelle");
                Console.WriteLine("8. Supprimer une nouvelle");
                Console.WriteLine("0. Quitter le programme");

                choixMenu = int.Parse(Console.ReadLine());

                switch (choixMenu)
                {
                    case 1:
                        ListerAbonnes();
                        break;
                    case 2:
                        AjouterAbonne();
                        break;
                    case 3:
                        BannirAbonne();
                        break;
                    case 4:
                        ListerNouvelles();
                        break;
                    case 5:
                        ConsulterNouvelle();
                        break;
                    case 6:
                        AjouterNouvelle();
                        break;
                    case 7:
                        RepondreNouvelle();
                        break;
                    case 8:
                        SupprimerNouvelle();
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

        private void ListerAbonnes()
        {
            if (_forum.Moderateur != null)
            {
                Console.WriteLine("=== Listing des Abonnés ===\n");
                _forum.Moderateur.ListerAbonnes();
            }
            else
            {
                Console.WriteLine("Ce forum n'a pas de modérateur !");
            }
        }

        private void AjouterAbonne()
        {
            if (_forum.Moderateur != null)
            {
                Console.WriteLine("=== Ajout d'Abonné ===\n");
                Console.Write("Quel est le nom de l'abonné ? ");
                string nomAbonne = Console.ReadLine();
                Console.Write("Quel est le prénom de l'abonné ? ");
                string prenomAbonne = Console.ReadLine();
                Console.Write("Quel est l'âge de l'abonné ? ");
                int ageAbonne = int.Parse(Console.ReadLine());

                Abonne nouvelAbonne = new Abonne(prenomAbonne, nomAbonne, ageAbonne, _forum);

                if (_forum.Moderateur.AjouterAbonne(nouvelAbonne))
                {
                    Console.WriteLine($"Abonné ajouté au forum !");
                }
                else
                {
                    Console.WriteLine("Impossible d'ajouter l'abonné ! Le forum est-il plein ?");
                }
            }
            else
            {
                Console.WriteLine("Ce forum n'a pas de modérateur !");
            }
        }

        private void BannirAbonne()
        {
            if (_forum.Moderateur != null)
            {
                Console.WriteLine("=== Bannir un Abonné ===\n");
                Console.Write("Quel est l'indice de l'abonné que vous souhaitez bannir ? ");
                int indiceABannir = int.Parse(Console.ReadLine());
                if (_forum.Moderateur.BannirAbonne(indiceABannir))
                {
                    Console.WriteLine($"L'abonné à l'indice {indiceABannir} a été banni du forum !");
                }
                else
                {
                    Console.WriteLine("Impossible de bannir cet abonné ! Est-ce le bon indice ?");
                }
            }
            else
            {
                Console.WriteLine("Ce forum n'a pas de modérateur !");
            }
        }

        private void ListerNouvelles()
        {
            if (_forum.Moderateur != null)
            {
                Console.WriteLine("=== Listing des Nouvelles ===\n");
                _forum.Moderateur.ListerNouvelles();
            }
            else
            {
                Console.WriteLine("Ce forum n'a pas de modérateur !");
            }
        }

        private void ConsulterNouvelle()
        {
            if (_forum.Abonnes[0] != null)
            {
                Console.WriteLine("=== Consulter une Nouvelle ===\n");
                Console.Write("Quel est l'indice de la nouvelle que vous souhaitez consulter ? ");
                int indiceAConsulter = int.Parse(Console.ReadLine());

                _forum.Abonnes[0].ConsulterNouvelle(indiceAConsulter);
            }
            else
            {
                Console.WriteLine("Le forum n'a pas d'abonnés pouvant effectuer cette action !");
            }
        }

        private void AjouterNouvelle()
        {
            if (_forum.Abonnes[0] != null)
            {
                Console.WriteLine("=== Ajouter une Nouvelle ===\n");
                Console.Write("Titre de la nouvelle : ");
                string nouveauTitre = Console.ReadLine();
                Console.Write("Descriptif de la nouvelle : ");
                string nouveauDescriptif = Console.ReadLine();

                Nouvelle nouvelleNouvelle = _forum.Abonnes[0].CreerNouvelle(nouveauTitre, nouveauDescriptif);

                if (_forum.Abonnes[0].AjouterNouvelle(nouvelleNouvelle))
                {
                    Console.WriteLine("Nouvelle ajoutée au forum !");
                }
                else
                {
                    Console.WriteLine("Impossible d'ajouter la nouvelle ! Le forum est-il plein ?");
                }

            }
            else
            {
                Console.WriteLine("Le forum n'a pas d'abonnés pouvant effectuer cette action !");
            }
        }

        private void RepondreNouvelle()
        {
            if (_forum.Abonnes[0] != null)
            {
                Console.WriteLine("=== Repondre à une Nouvelle ===\n");
                Console.Write("A quelle nouvelle souhaitez vous répondre ? Donnez son indice : ");
                int indiceARepondre = int.Parse(Console.ReadLine());

                Console.Write("Titre de la réponse : ");
                string nouveauTitreReponse = Console.ReadLine();
                Console.Write("Descriptif de la réponse : ");
                string nouveauDescriptifReponse = Console.ReadLine();

                Nouvelle nouvelleReponse = _forum.Abonnes[0].CreerNouvelle(nouveauTitreReponse, nouveauDescriptifReponse);

                if (_forum.Abonnes[0].AjouterReponse(nouvelleReponse, indiceARepondre))
                {
                    Console.WriteLine("Reponse ajoutée au forum !");
                }
                else
                {
                    Console.WriteLine("Impossible d'ajouter la réponse ! Le forum est-il plein ?");
                }

            }
            else
            {
                Console.WriteLine("Le forum n'a pas d'abonnés pouvant effectuer cette action !");
            }
        }

        private void SupprimerNouvelle()
        {
            if (_forum.Moderateur != null)
            {
                Console.WriteLine("=== Supprimer une Nouvelle ===\n");
                Console.Write("Quel est l'indice de la nouvelle que vous souhaitez supprimer ? ");
                int indiceASupprimer = int.Parse(Console.ReadLine());
                if (_forum.Moderateur.SupprimerNouvelle(indiceASupprimer))
                {
                    Console.WriteLine($"La nouvelle à l'indice {indiceASupprimer} a été supprimée du forum !");
                }
                else
                {
                    Console.WriteLine("Impossible de supprimer cette nouvelle ! Est-ce le bon indice ?");
                }
            }
            else
            {
                Console.WriteLine("Ce forum n'a pas de modérateur !");
            }
        }
    }
}
