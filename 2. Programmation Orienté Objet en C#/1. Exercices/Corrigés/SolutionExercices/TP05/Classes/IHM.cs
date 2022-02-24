using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05.Classes
{
    internal class IHM
    {
        private Salarie[] _salaries;

        public IHM(int tailleEntreprise = 20)
        {
            _salaries = new Salarie[tailleEntreprise];
        }

        public void Demarrer()
        {
            int choixMenu = -1;

            do
            {
                Console.WriteLine("=== Gestion des Employés ===\n");

                Console.WriteLine("1. Ajouter un employé");
                Console.WriteLine("2. Afficher le salaire des employés");
                Console.WriteLine("3. Rechercher un employé");
                Console.WriteLine("0. Quitter");

                Console.Write("Entrez votre choix : ");
                choixMenu = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choixMenu)
                {
                    case 0:
                        break;
                    case 1:
                        AjouterEmploye();
                        break;
                    case 2:
                        AfficherSalaireEmployes();
                        break;
                    case 3:
                        RechercherEmploye();
                        break;
                    default:
                        Console.WriteLine("Ce choix n'est pas disponible !");
                        break;
                }

                Console.WriteLine("");

            } while (choixMenu != 0);
        }

        private void AjouterEmploye()
        {
            int choixTypeEmploye = -1;

            do
            {
                Console.WriteLine("=== Ajouter un employé ===\n");

                Console.WriteLine("1. Salarié");
                Console.WriteLine("2. Commercial");
                Console.WriteLine("0. Retour");

                Console.Write("Entrez votre choix : ");
                choixTypeEmploye = int.Parse(Console.ReadLine());

                switch (choixTypeEmploye)
                {
                    case 0:
                        break;
                    case 1:
                        CreerSalarie();
                        break;
                    case 2:
                        CreerCommercial();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixTypeEmploye != 0);
        }

        private void CreerSalarie()
        {
            int indiceVierge = Array.FindIndex(_salaries, s => s == null);
            if (indiceVierge != -1)
            {
                Console.Write("Quel est le nom de l'employé ? ");
                string nomEmploye = Console.ReadLine();
                Console.Write("Quel est la catégorie de l'employé ? ");
                string categorieEmploye = Console.ReadLine();
                Console.Write("Quel est le service de l'employé ? ");
                string serviceEmploye = Console.ReadLine();
                Console.Write("Quel est le salaire de l'employé ? ");
                double salaireEmploye = double.Parse(Console.ReadLine());


                Salarie nouveauSalarie = new Salarie(categorieEmploye, serviceEmploye, nomEmploye, salaireEmploye);
                _salaries[indiceVierge] = nouveauSalarie;
                Console.WriteLine($"{nouveauSalarie.Nom} a bien été ajouté à l'entreprise !");
            }
            else
            {
                Console.WriteLine("Désole, l'entreprise est déjà pleine !");
            }

        }

        private void CreerCommercial()
        {
            int indiceVierge = Array.FindIndex(_salaries, s => s == null);
            if (indiceVierge != -1)
            {
                Console.Write("Quel est le nom de l'employé ? ");
                string nomEmploye = Console.ReadLine();
                Console.Write("Quel est la catégorie de l'employé ? ");
                string categorieEmploye = Console.ReadLine();
                Console.Write("Quel est le service de l'employé ? ");
                string serviceEmploye = Console.ReadLine();
                Console.Write("Quel est le salaire de l'employé ? ");
                double salaireEmploye = double.Parse(Console.ReadLine());
                Console.Write("Quel est le chiffre d'affaire de l'employé ? ");
                double chiffreAffEmploye = double.Parse(Console.ReadLine());
                Console.Write("Quel est le pourcentage de comission de l'employé ? ");
                int comissionEmploye = int.Parse(Console.ReadLine());

                Commercial nouveauSalarie = new Commercial(categorieEmploye, serviceEmploye, nomEmploye, salaireEmploye, chiffreAffEmploye, comissionEmploye);
                _salaries[indiceVierge] = nouveauSalarie;
                Console.WriteLine($"{nouveauSalarie.Nom} a bien été ajouté à l'entreprise !");
            }
            else
            {
                Console.WriteLine("Désole, l'entreprise est déjà pleine !");
            }
        }

        private void AfficherSalaireEmployes()
        {
            Console.WriteLine($"Le salaire total des employés est de {Salarie.TotalSalaires} euros");
        }

        private void RechercherEmploye()
        {
            Console.Write("Quel est l'ID de l'employé que vous voulez consulter ? ");
            int idSalarie = int.Parse(Console.ReadLine());

            if (_salaries[idSalarie] != null) _salaries[idSalarie].AfficherSalaire();
            else Console.WriteLine("Il n'y a pas d'employé à cet ID...");
        }
    }
}
