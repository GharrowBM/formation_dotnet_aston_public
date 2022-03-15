using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02.Classes
{
    internal class IHM
    {
        private string _connectionString;

        public IHM(string connectionString)
        {
            _connectionString = connectionString; 
        }
        public void Demarrer()
        {
            InitDatabase();

            int choixMenuPrincipal = -1;

            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Voir les contacts");
                Console.WriteLine("2. Ajouter un contact");
                Console.WriteLine("3. Modifier un contact");
                Console.WriteLine("4. Supprimer un contact");
                Console.WriteLine("5. Voir les adresses");
                Console.WriteLine("6. Ajouter une adresse");
                Console.WriteLine("7. Modifier une adresse");
                Console.WriteLine("8. Supprimer une adresse");
                Console.WriteLine("9. Gérer des déménagements");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Votre choix : ");
                choixMenuPrincipal = int.Parse(Console.ReadLine() ?? "0");

                switch (choixMenuPrincipal)
                {
                    case 0:
                        break;
                    case 1:
                        VoirContacts();
                        break;
                    case 2:
                        CreerContact();
                        break;
                    case 3:
                        ModifierContact();
                        break;
                    case 4:
                        SupprimerContact();
                        break;
                    case 5:
                        VoirAdresses();
                        break;
                    case 6:
                        CreerAdresse();
                        break;
                    case 7:
                        ModifierAdresse();
                        break;
                    case 8:
                        SupprimerAdresse();
                        break;
                    case 9:
                        MenuDemenagements();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenuPrincipal != 0);


        }

        private void MenuDemenagements()
        {
            int choixMenuDemenagements = -1;

            do
            {
                Console.WriteLine("=== GESTION DES DEMENAGEMENTS ===\n");

                Console.WriteLine("1. Faire eménager un contact");
                Console.WriteLine("2. Faire déménager un contact");
                Console.WriteLine("3. Voir les adresses d'un contact");
                Console.WriteLine("4. Voir les habitants d'une adresse");
                Console.WriteLine("0. Quitter la gestion des déménagements");

                Console.Write("Votre choix : ");
                choixMenuDemenagements = int.Parse(Console.ReadLine() ?? "0");

                switch (choixMenuDemenagements)
                {
                    case 0:
                        break;
                    case 1:
                        Emmenager();
                        break;
                    case 2:
                        Demenager();
                        break;
                    case 3:
                        VoirLogementsDe();
                        break;
                    case 4:
                        VoirHabitantsDe();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("");

            } while (choixMenuDemenagements != 0);
        }

        private void Emmenager()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.Write("Quel ID contact ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "SELECT nom FROM contacts WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string nomTrouve = (string) command.ExecuteScalar();
                command.Dispose();
                if (nomTrouve != null)
                {
                    Console.Write("Quel ID de l'adresse ?");
                    int adresseID = int.Parse(Console.ReadLine());

                    request = "SELECT ville FROM adresses WHERE Id = @id;";
                    command = new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@id", adresseID));

                    string villeTrouvee = (string) command.ExecuteScalar();
                    command.Dispose();
                    if (villeTrouvee != null)
                    {
                        request = "INSERT INTO contacts_adresses (contactId, adresseId) VALUES (@cId, @aId);";
                        command = new SqlCommand(request, connection);
                        command.Parameters.Add(new SqlParameter("@cId", contactId));
                        command.Parameters.Add(new SqlParameter("@aId", adresseID));

                        int nbRows = command.ExecuteNonQuery();
                        command.Dispose();
                        if (nbRows > 0)
                        {
                                Console.WriteLine("Emménagement effectué !");
                        }
                        else
                        {
                            Console.WriteLine("ERREUR : L'emménagement n'a pas eu lieu !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Il n'y a pas d'adresse avec cet ID !");
                    }
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de contact avec cet ID !");
                }
            }
            connection.Close();
        }

        private void Demenager()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.Write("Quel ID contact ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "SELECT nom FROM contacts WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string nomTrouve = (string)command.ExecuteScalar();
                command.Dispose();
                if (nomTrouve != null)
                {
                    Console.Write("Quel ID de l'adresse ?");
                    int adresseID = int.Parse(Console.ReadLine());

                    request = "SELECT ville FROM adresses WHERE Id = @id;";
                    command = new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@id", adresseID));

                    string villeTrouvee = (string)command.ExecuteScalar();
                    command.Dispose();
                    if (villeTrouvee != null)
                    {
                        request = "DELETE FROM contacts_adresses WHERE contactId = @cId AND adresseId = @aId;";
                        command = new SqlCommand(request, connection);
                        command.Parameters.Add(new SqlParameter("@cId", contactId));
                        command.Parameters.Add(new SqlParameter("@aId", adresseID));

                        int nbRows = command.ExecuteNonQuery();
                        if (nbRows > 0)
                        {
                            Console.WriteLine("Déménagement effectué !");
                        }
                        else
                        {
                            Console.WriteLine("ERREUR : Le Déménagement n'a pas eu lieu !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Il n'y a pas d'adresse avec cet ID !");
                    }
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de contact avec cet ID !");
                }
            }
            connection.Close();
        }

        private void VoirLogementsDe()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.Write("Quel ID contact ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "SELECT nom FROM contacts WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string nomTrouve = (string)command.ExecuteScalar();
                command.Dispose();
                if (nomTrouve != null)
                {
                    request = "SELECT adr.id, adr.numero, adr.rue, adr.code_postal, adr.ville FROM adresses AS adr "
                        + "LEFT JOIN contacts_adresses AS con_adr ON adr.id = con_adr.adresseId "
                        + "WHERE con_adr.contactId = @id;";
                    command= new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@id", contactId));

                    SqlDataReader reader = command.ExecuteReader();
                    command.Dispose();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}. {reader.GetInt32(1)} {reader.GetString(2)} - {reader.GetInt32(3)} {reader.GetString(4)}");
                    }
                    reader.Close();
                }
                else
                {
                    Console.WriteLine("Il n'y a pas de contact avec cet ID !");
                }
            }
            connection.Close();
        }

        private void VoirHabitantsDe()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.Write("Quel ID adresse ? ");
            int adresseId = int.Parse(Console.ReadLine());

            string request = "SELECT ville FROM adresses WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", adresseId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string villeTrouvee = (string)command.ExecuteScalar();
                command.Dispose();
                if (villeTrouvee != null)
                {
                    request = "SELECT con.id, con.nom, con.prenom, con.phone, con.email FROM contacts AS con "
                        + "LEFT JOIN contacts_adresses AS con_adr ON con.id = con_adr.contactId "
                        + "WHERE con_adr.adresseId = @id;";
                    command = new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@id", adresseId));

                    SqlDataReader reader = command.ExecuteReader();
                    command.Dispose();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}. Nom : {reader.GetString(1)}, Prenom : {reader.GetString(2)}, Téléphone : {reader.GetString(3)}, Email : {reader.GetString(4)}");
                    }
                    reader.Close();
                }
                else
                {
                    Console.WriteLine("Il n'y a pas d'adresse avec cet ID !");
                }
            }
            connection.Close();
        }

        private void InitDatabase()
        {
            CreateTableContacts();
            CreateTableAdresses();
            CreateTableContactsAdresses();
        }

        private void CreateTableContacts()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string request = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'contacts';";
            SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                if (command.ExecuteScalar() == null)
                {
                    command.Dispose();
                    Console.WriteLine("Table des contacts introuvable ! Création...");
                    request = "CREATE TABLE [dbo].[contacts] ("
                        + "[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),"
                        + "[Nom] NVARCHAR(50) NOT NULL,"
                        + "[Prenom] NVARCHAR(50) NOT NULL,"
                        + "[Phone] NVARCHAR(50) NOT NULL,"
                        + "[Email] NVARCHAR(50) NOT NULL"
                        + ")";
                    command = new SqlCommand(request, connection);
                    int nbRows = command.ExecuteNonQuery();
                    command.Dispose();
                    Console.WriteLine("Table des contacts créée !");

                }
                else
                {
                    Console.WriteLine("Table des contacts trouvée !");
                }
            }
            connection.Close();
        }

        private void CreateTableAdresses()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string request = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'adresses';";
            SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                if (command.ExecuteScalar() == null)
                {
                    command.Dispose();
                    Console.WriteLine("Table des adresses introuvable ! Création...");
                    request = "CREATE TABLE [dbo].[adresses] ("
                                + "[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),"
                                + "[Numero] INT NOT NULL,"
                                + "[Rue] NVARCHAR(50) NOT NULL,"
                                + "[Code_Postal] INT NOT NULL,"
                                + "[Ville] NVARCHAR(50) NOT NULL"
                                + ")";
                    command = new SqlCommand(request, connection);
                    int nbRows = command.ExecuteNonQuery();
                    command.Dispose();
                    Console.WriteLine("Table des adresses créée !");
                }
                else
                {
                    Console.WriteLine("Table des adresses trouvée !");
                }
            }
            connection.Close();
        }

        private void CreateTableContactsAdresses()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string request = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'contacts_adresses';";
            SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                if (command.ExecuteScalar() == null)
                {
                    command.Dispose();
                    Console.WriteLine("Table de jointure contacts_adresses introuvable ! Création...");
                    request = "CREATE TABLE [dbo].[contacts_adresses] ("
                                + "[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),"
                                + "[ContactId] INT NOT NULL,"
                                + "[AdresseId] INT NOT NULL"
                                + ")";
                    command = new SqlCommand(request, connection);
                    int nbRows = command.ExecuteNonQuery();
                    command.Dispose();
                    Console.WriteLine("Table de jointure contacts_adresses créée !");
                }
                else
                {
                    Console.WriteLine("Table de jointure contacts_adresses trouvée !");
                }
            }
            connection.Close();
        }

        private void CreerContact()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Créer un Contact ===\n");
            Console.Write("Donnez le nom du contact : ");
            string nom = Console.ReadLine();
            Console.Write("Donnez le prénom du contact : ");
            string prenom = Console.ReadLine();
            Console.Write("Donnez le numéro de téléphone du contact : ");
            string phone = Console.ReadLine();
            Console.Write("Donnez l'adresse mail du contact : ");
            string mail = Console.ReadLine();


            string request = "INSERT INTO contacts (nom, prenom, phone, email) OUTPUT INSERTED.Id values (@nom, @prenom, @phone, @mail);";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@phone", phone));
            command.Parameters.Add(new SqlParameter("@mail", mail));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                int id = (int)command.ExecuteScalar();
                command.Dispose();
                if (id != 0) Console.WriteLine($"Le contact a été ajouté ! ID : {id}");
            }
            connection.Close();

        }

        private void CreerAdresse()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Créer une Adresse ===\n");
            Console.Write("Donnez le numéro de rue : ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Donnez le nom de la rue : ");
            string rue = Console.ReadLine();
            Console.Write("Donnez le code postal : ");
            int codePostal = int.Parse(Console.ReadLine());
            Console.Write("Donnez la ville : ");
            string ville = Console.ReadLine();


            string request = "INSERT INTO adresses (numero, rue, code_postal, ville) OUTPUT INSERTED.Id values (@numero, @rue, @codePostal, @ville);";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@numero", numero));
            command.Parameters.Add(new SqlParameter("@rue", rue));
            command.Parameters.Add(new SqlParameter("@codePostal", codePostal));
            command.Parameters.Add(new SqlParameter("@ville", ville));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                int id = (int)command.ExecuteScalar();
                command.Dispose();
                if (id != 0) Console.WriteLine($"L'adresse a été ajoutée ! ID : {id}");
            }
            connection.Close();
        }

        private void VoirContacts()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Liste des Contacts ===\n");

            string request = "SELECT contacts.id, nom, prenom, phone, email, COUNT(*) "
                + "FROM contacts "
                + "INNER JOIN contacts_adresses ON contacts.id = contactId "
                + "GROUP BY contacts.id, nom, prenom, phone, email;";
            SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                SqlDataReader reader = command.ExecuteReader();
                command.Dispose();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}. Nom : {reader.GetString(1)}, Prenom : {reader.GetString(2)}, Téléphone : {reader.GetString(3)}, Email : {reader.GetString(4)} (Logements : {reader.GetInt32(5)})");
                }
                reader.Close();
            }
            connection.Close();
        }

        private void VoirAdresses()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Liste des Adresses ===\n");

            string request = "SELECT adresses.id, numero, rue, code_postal, ville, COUNT(*) "
                + "FROM adresses "
                + "INNER JOIN contacts_adresses ON adresses.id = adresseId "
                + "GROUP BY adresses.id, numero, rue, code_postal, ville;";
            SqlCommand command = new SqlCommand(request, connection);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                SqlDataReader reader = command.ExecuteReader();
                command.Dispose();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}. {reader.GetInt32(1)} {reader.GetString(2)} - {reader.GetInt32(3)} {reader.GetString(4)} (Habitants : {reader.GetInt32(5)})");
                }
                reader.Close();
            }
            connection.Close();
        }

        private void ModifierContact()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Modifier un contact ===\n");

            Console.Write("Quel est l'ID du contact à modifier ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "SELECT nom FROM contacts WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string nomTrouve = (string) command.ExecuteScalar();
                if (nomTrouve != null)
                {
                    command.Dispose();

                    Console.Write("Nouveau nom : ");
                    string nouveauNom = Console.ReadLine();
                    Console.Write("Nouveau prenom : ");
                    string nouveauPrenom = Console.ReadLine();
                    Console.Write("Nouveau numéro de téléphone : ");
                    string nouveauPhone = Console.ReadLine();
                    Console.Write("Nouveau mail : ");
                    string nouveauMail = Console.ReadLine();

                    request = "UPDATE contacts SET nom = @nom, prenom = @prenom, phone = @phone, email = @mail WHERE id = @id;";
                    command = new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@prenom", nouveauPrenom));
                    command.Parameters.Add(new SqlParameter("@nom", nouveauNom));
                    command.Parameters.Add(new SqlParameter("@phone", nouveauPhone));
                    command.Parameters.Add(new SqlParameter("@mail", nouveauMail));
                    command.Parameters.Add(new SqlParameter("@id", contactId));

                    int rowEdited = command.ExecuteNonQuery();
                    if (rowEdited > 0)
                    {
                        Console.WriteLine("Le contact a bien été édité !");
                    }
                    else
                    {
                        Console.WriteLine("ERREUR : Edition impossible !");
                    }
                }
                else
                {
                    Console.WriteLine("Il n'y a aucun contact avec cet ID !");
                }
            }
            connection.Close();
        }

        private void ModifierAdresse()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Modifier une adresse ===\n");

            Console.Write("Quel est l'ID de l'adresse à modifier ? ");
            int adresseId = int.Parse(Console.ReadLine());

            string request = "SELECT ville FROM adresses WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", adresseId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                string villeTrouvee = (string)command.ExecuteScalar();
                if (villeTrouvee != null)
                {
                    command.Dispose();

                    Console.Write("Nouveau numéro : ");
                    int nouveauNumero = int.Parse(Console.ReadLine());
                    Console.Write("Nouvelle rue: ");
                    string nouvelleRue = Console.ReadLine();
                    Console.Write("Nouveau code postal : ");
                    int nouveauCodePostal = int.Parse(Console.ReadLine());
                    Console.Write("Nouvelle ville : ");
                    string nouvelleVille = Console.ReadLine();

                    request = "UPDATE adresses SET numero = @numero, rue = @rue, code_postal = @codePostal, ville = @ville WHERE id = @id;";
                    command = new SqlCommand(request, connection);
                    command.Parameters.Add(new SqlParameter("@numero", nouveauNumero));
                    command.Parameters.Add(new SqlParameter("@rue", nouvelleRue));
                    command.Parameters.Add(new SqlParameter("@codePostal", nouveauCodePostal));
                    command.Parameters.Add(new SqlParameter("@ville", nouvelleVille));
                    command.Parameters.Add(new SqlParameter("@id", adresseId));

                    int rowEdited = command.ExecuteNonQuery();
                    if (rowEdited > 0)
                    {
                        Console.WriteLine("L'adresse a bien été éditée !");
                    }
                    else
                    {
                        Console.WriteLine("ERREUR : Edition impossible !");
                    }
                }
                else
                {
                    Console.WriteLine("Il n'y a aucune adresse avec cet ID !");
                }
            }
            connection.Close();
        }

        private void SupprimerContact()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Supprimer un contact ===\n");

            Console.Write("Quel est l'ID du contact à supprimer ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "DELETE FROM contacts WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                int nbRows = (int) command.ExecuteNonQuery();
                command.Dispose();
                if (nbRows == 1)
                {
                    Console.WriteLine("Le contact a bien été supprimé !");
                }
                else
                {
                    Console.WriteLine("ERREUR : La suppression du contact a echoué !");
                }
            }
            connection.Close();
        }

        private void SupprimerAdresse()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("=== Supprimer une adresse ===\n");

            Console.Write("Quel est l'ID de l'adresse à supprimer ? ");
            int contactId = int.Parse(Console.ReadLine());

            string request = "DELETE FROM adresses WHERE Id = @id;";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", contactId));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                int nbRows = (int)command.ExecuteNonQuery();
                command.Dispose();
                if (nbRows == 1)
                {
                    Console.WriteLine("L'adresse a bien été supprimée !");
                }
                else
                {
                    Console.WriteLine("ERREUR : La suppression de l'adresse a echoué !");
                }
            }
            connection.Close();
        }
    }
}
