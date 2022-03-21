using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP06.Datas;

namespace TP06.Classes
{
    internal class IHM
    {
        private UtilisateurRepository _users;
        private CommentaireRepository _comments;
        private QuestionRepository _questions;
        private ReponseRepository _answers;

        public IHM()
        {
            _users = new UtilisateurRepository();
            _comments = new CommentaireRepository();
            _questions = new QuestionRepository();
            _answers = new ReponseRepository();
        }

        public void Demarrer()
        {
            int choixMenuPrincipal = -1;

            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Gérer les questions");
                Console.WriteLine("2. Gérer les Utilisateurs");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Votre choix : ");
                choixMenuPrincipal = Convert.ToInt32(Console.ReadLine());

                switch (choixMenuPrincipal)
                {
                    case 0:
                        break;
                    case 1:
                        GestionQuestions();
                        break;
                    case 2:
                        GestionUtilisateurs();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenuPrincipal != 0);
        }

        private void GestionQuestions()
        {
            int choixGestionQuestion = -1;

            do
            {
                Console.WriteLine("=== Gestion des questions ===\n");

                Console.WriteLine("1. Voir les questions");
                Console.WriteLine("2. Poser une question");
                Console.WriteLine("3. Editer une question");
                Console.WriteLine("4. Répondre à une question");
                Console.WriteLine("5. Editer une réponse");
                Console.WriteLine("6. Commenter une réponse");
                Console.WriteLine("7. Editer un commentaire");
                Console.WriteLine("0. Retour");

                Console.Write("Votre choix : ");
                choixGestionQuestion = Convert.ToInt32(Console.ReadLine());

                switch (choixGestionQuestion)
                {
                    case 0:
                        break;
                    case 1:
                        VoirQuestions();
                        break;
                    case 2:
                        PoserQuestion();
                        break;
                    case 3:
                        EditerQuestion();
                        break;
                    case 4:
                        Repondre();
                        break;
                    case 5:
                        EditerReponse();
                        break;
                    case 6:
                        Commenter();
                        break;
                    case 7:
                        EditerCommentaire();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixGestionQuestion != 0);
        }

        private void VoirQuestions()
        {
            Console.WriteLine("=== Liste des questions ===\n");

            _questions.GetAll().ForEach(question =>
            {
                question.Score++;
                Console.WriteLine($"{question.Id} {question.Title} par {question.Posteur.Prenom} {question.Posteur.Nom} - Score : {question.Score}, {question.Reponses.Count} réponses");
                Console.WriteLine($"\t{question.Description}");
                if (question.Reponses.Count > 0)
                {
                    Console.WriteLine("Réponses :");
                    question.Reponses.ForEach(reponse =>
                    {
                        reponse.Score++;
                        Console.WriteLine($"\t{reponse.Id}. {reponse.Title} par {reponse.Posteur.Prenom} {reponse.Posteur.Nom} - Score : {reponse.Score}, {reponse.Commentaires.Count} commentaires");
                        Console.WriteLine($"\t\t{reponse.Description}");
                        if(reponse.Commentaires.Count > 0)
                        {
                            Console.WriteLine("\tCommentaires :");
                            reponse.Commentaires.ForEach(commentaire =>
                            {
                                commentaire.Score++;
                                Console.WriteLine($"\t\t{commentaire.Id} {commentaire.Title} par {commentaire.Posteur.Prenom} {commentaire.Posteur.Nom} - Score : {commentaire.Score}");
                                Console.WriteLine($"\t\t\t{commentaire.Description}");
                            });
                        }
                    });
                }

                _questions.Update(question.Id, question);
            });
        }

        private void PoserQuestion()
        {
            Console.Write("Quel ID utilisateur ? : ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Utilisateur user = _users.Get(userId);
            if (user == null) Console.WriteLine("Aucun utilisateur avec cet ID !");
            else
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();
                Console.Write("Description : ");
                string description = Console.ReadLine();

                Question nouvelleQuestion = new Question()
                {
                    Title = titre,
                    Description = description,
                    Score = 0,
                    PosteurId = userId
                };

                if (_questions.Add(nouvelleQuestion) != null) Console.WriteLine("Question postée !");
            }
        }

        private void EditerQuestion()
        {
            Console.Write("Quel ID question ? ");
            int questionId = Convert.ToInt32(Console.ReadLine());

            Question question = _questions.Get(questionId);
            if (question == null) Console.WriteLine("Aucune question avec cet ID !");
            else
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();
                Console.Write("Description : ");
                string description = Console.ReadLine();

                question.Title = titre;
                question.Description = description;
                question.Score++;

                if (_questions.Update(questionId, question) != null) Console.WriteLine("Question modifiée !");
            }
        }

        private void Repondre()
        {
            Console.Write("Quel ID utilisateur ? : ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Utilisateur user = _users.Get(userId);
            if (user == null) Console.WriteLine("Aucun utilisateur avec cet ID !");
            else
            {
                Console.Write("Quel ID question ? : ");
                int questionId = Convert.ToInt32(Console.ReadLine());

                Question question = _questions.Get(questionId);
                if (question == null) Console.WriteLine("Aucune question avec cet ID !");
                else
                {
                    Console.Write("Titre : ");
                    string titre = Console.ReadLine();
                    Console.Write("Description : ");
                    string description = Console.ReadLine();

                    Reponse nouvelleReponse = new Reponse()
                    {
                        Title = titre,
                        Description = description,
                        Score = 0,
                        PosteurId = userId
                    };

                    question.Reponses.Add(nouvelleReponse);
                    if (_questions.Update(questionId, question) != null) Console.WriteLine("Reponse postée !");
                }
                
            }
        }

        private void EditerReponse()
        {
            Console.Write("Quel ID réponse ? ");
            int reponseId = Convert.ToInt32(Console.ReadLine());

            Reponse reponse = _answers.Get(reponseId);
            if (reponse == null) Console.WriteLine("Aucune réponse avec cet ID !");
            else
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();
                Console.Write("Description : ");
                string description = Console.ReadLine();

                reponse.Title = titre;
                reponse.Description = description;
                reponse.Score++;

                if (_answers.Update(reponseId, reponse) != null) Console.WriteLine("Réponse modifiée !");
            }
        }

        private void Commenter()
        {
            Console.Write("Quel ID utilisateur ? : ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Utilisateur user = _users.Get(userId);
            if (user == null) Console.WriteLine("Aucun utilisateur avec cet ID !");
            else
            {
                Console.Write("Quel ID question ? : ");
                int questionId = Convert.ToInt32(Console.ReadLine());

                Question question = _questions.Get(questionId);
                if (question == null) Console.WriteLine("Aucune question avec cet ID !");
                else
                {
                    Console.Write("Quel ID réponse ? ");
                    int reponseId = Convert.ToInt32(Console.ReadLine());

                    Reponse reponse = _answers.Get(reponseId);
                    if (reponse == null) Console.WriteLine("Aucune réponse avec cet ID !");
                    else
                    {
                        Console.Write("Titre : ");
                        string titre = Console.ReadLine();
                        Console.Write("Description : ");
                        string description = Console.ReadLine();

                        Commentaire nouveauCommentaire = new Commentaire()
                        {
                            Title = titre,
                            Description = description,
                            Score = 0,
                            PosteurId = userId
                        };

                        reponse.Commentaires.Add(nouveauCommentaire);
                        if (_questions.Update(questionId, question) != null && _answers.Update(reponseId, reponse) != null) Console.WriteLine("Commentaire posté !");
                    }
                    
                }

            }
        }

        private void EditerCommentaire()
        {
            Console.Write("Quel ID commentaire ? ");
            int commentaireId = Convert.ToInt32(Console.ReadLine());

            Commentaire commentaire = _comments.Get(commentaireId);
            if (commentaire == null) Console.WriteLine("Aucun commentaire avec cet ID !");
            else
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();
                Console.Write("Description : ");
                string description = Console.ReadLine();

                commentaire.Title = titre;
                commentaire.Description = description;
                commentaire.Score++;

                if (_comments.Update(commentaireId, commentaire) != null) Console.WriteLine("Commentaire modifié !");
            }
        }

        private void GestionUtilisateurs()
        {
            int choixGestionQuestion = -1;

            do
            {
                Console.WriteLine("=== Gestion des utilisateurs ===\n");

                Console.WriteLine("1. Voir les utilisateurs");
                Console.WriteLine("2. Ajouter un utilisateur");
                Console.WriteLine("3. Modifier un utilisateur");
                Console.WriteLine("4. Supprimer un utilisateur");
                Console.WriteLine("0. Retour");

                Console.Write("Votre choix : ");
                choixGestionQuestion = Convert.ToInt32(Console.ReadLine());

                switch (choixGestionQuestion)
                {
                    case 0:
                        break;
                    case 1:
                        VoirUtilisateurs();
                        break;
                    case 2:
                        AjouterUtilisateur();
                        break;
                    case 3:
                        ModifierUtilisateur();
                        break;
                    case 4:
                        SupprimerUtilisateur();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixGestionQuestion != 0);
        }

        private void VoirUtilisateurs()
        {
            Console.WriteLine("=== Liste des utilisateurs ===\n");

            _users.GetAll().ForEach(user =>
            {
                Console.WriteLine($"{user.Id}. {user.Prenom} {user.Nom} - Téléphone : {user.Telephone}, Email : {user.Email}");
            });
        }

        private void AjouterUtilisateur()
        {
            Console.WriteLine("=== Ajouter un utilisateur ===\n");

            Console.Write("Prenom de l'utilisateur : ");
            string prenom = Console.ReadLine();
            Console.Write("Nom de l'utilisateur : ");
            string nom = Console.ReadLine();
            Console.Write("Téléphone de l'utilisateur : ");
            string telephone = Console.ReadLine();
            Console.Write("Email de l'utilisateur : ");
            string email = Console.ReadLine();

            Utilisateur nouvelUtilisateur = new Utilisateur()
            {
                Prenom = prenom,
                Nom = nom,
                Telephone = telephone,
                Email = email
            };

            if (_users.Add(nouvelUtilisateur) != null) Console.WriteLine("Utilisateur ajouté !");
        }

        private void ModifierUtilisateur()
        {
            Console.WriteLine("=== Modifier un utilisateur ===\n");

            Console.Write("ID à modifier : ");
            int utilisateurId = Convert.ToInt32(Console.ReadLine());

            Utilisateur utilisateurTrouve = _users.Get(utilisateurId);

            if (utilisateurTrouve == null) Console.WriteLine("Aucun utilisateur avec cet ID !");
            else
            {
                Console.Write("Prenom de l'utilisateur : ");
                string prenom = Console.ReadLine();
                Console.Write("Nom de l'utilisateur : ");
                string nom = Console.ReadLine();
                Console.Write("Téléphone de l'utilisateur : ");
                string telephone = Console.ReadLine();
                Console.Write("Email de l'utilisateur : ");
                string email = Console.ReadLine();

                utilisateurTrouve.Prenom = prenom;
                utilisateurTrouve.Nom = nom;
                utilisateurTrouve.Telephone = telephone;
                utilisateurTrouve.Email = email;


                if (_users.Update(utilisateurId, utilisateurTrouve) != null) Console.WriteLine("Utilisateur modifié !");
            }

        }

        private void SupprimerUtilisateur()
        {
            Console.WriteLine("=== Supprimer un utilisateur ===\n");

            Console.Write("ID à modifier : ");
            int utilisateurId = Convert.ToInt32(Console.ReadLine());

            Utilisateur utilisateurTrouve = _users.Get(utilisateurId);

            if (utilisateurTrouve == null) Console.WriteLine("Aucun utilisateur avec cet ID !");
            else
            {
                if (_users.Delete(utilisateurId)) Console.WriteLine("Utilisateur supprimé !");
            }
        }
    }
}
