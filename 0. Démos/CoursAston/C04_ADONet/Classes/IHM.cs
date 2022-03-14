using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04_ADONet.Classes
{
    internal class IHM
    {
        private string _connectionString;

        public IHM(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Run()
        {
            InitDb();

            int choixMenuPrincipal = -1;

            do
            {
                Console.WriteLine("=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Voir les chiens");
                Console.WriteLine("2. Ajouter un chien");
                Console.WriteLine("3. Éditer un chien");
                Console.WriteLine("4. Supprimer un chien");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Votre choix : ");
                int.TryParse(Console.ReadLine(), out choixMenuPrincipal);

                switch (choixMenuPrincipal)
                {
                    case 0:
                        break;
                    case 1:
                        SeeDogs();
                        break;
                    case 2:
                        AddDog();
                        break;
                    case 3:
                        EditDog();
                        break;
                    case 4:
                        DeleteDog();
                        break;
                }

            } while (choixMenuPrincipal != 0);
        }
        private void InitDb()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'masters'";

            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'dogs'";

            try
            {
                connection.Open();
                if(connection.State == ConnectionState.Open)
                {
                    if (cmd.ExecuteScalar() == null)
                    {
                        Console.WriteLine("Table des maîtres introuvable ! Création...");
                        cmd.CommandText = "CREATE TABLE [dbo].[masters] ("
                            + "[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),"
                            + "[FirstName] NVARCHAR(50) NOT NULL,"
                            + "[LastName] NVARCHAR(50) NOT NULL,"
                            + ")";

                        int nbRows = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        Console.WriteLine("Table des maîtres créée !");
                    }
                    else
                    {
                        Console.WriteLine("Table des maîtres trouvée !");
                    }

                    if (cmd2.ExecuteScalar() == null)
                    {
                        Console.WriteLine("Table des chiens introuvable ! Création...");
                        cmd2.CommandText = "CREATE TABLE [dbo].[dogs] ("
                            + "[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),"
                            + "[Name] NVARCHAR(50) NOT NULL,"
                            + "[CollarColor] NVARCHAR(50) NOT NULL,"
                            + "[NbrOfLegs] INT NOT NULL,"
                            + "[MasterId] INT NOT NULL,"
                            + "CONSTRAINT[FK_dogs_masters] FOREIGN KEY([MasterId]) REFERENCES[dbo].[masters]([Id])"
                        + ")";

                        int nbRows = cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        Console.WriteLine("Table des chiens créée !");
                    }
                    else
                    {
                        Console.WriteLine("Table des chiens trouvée !");
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            } finally
            {
                connection.Close();
            }
        }

        private void SeeDogs()
        {
            Console.WriteLine("=== Liste des Chiens ===\n");


            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT dogs.Id, Name, CollarColor, NbrOfLegs, masters.FirstName, masters.LastName FROM dogs INNER JOIN masters ON dogs.MasterId = masters.Id;";

            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}. Nom : {reader.GetString(1)}, Couleur du collier : {reader.GetString(2)}, Nombre de pattes : {reader.GetInt32(3)}, Maître : {reader.GetString(4)} {reader.GetString(5)}");
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void AddDog()
        {
            Console.WriteLine("=== Ajouter un Chien ===\n");

            Console.Write("Nom du chien : ");
            string dogName = Console.ReadLine();
            Console.Write("Nombre de pattes du chien : ");
            int dogNbrOfLegs = 4;
            int.TryParse(Console.ReadLine(), out dogNbrOfLegs);
            Console.Write("Couleur du collier du chien : ");
            string dogCollarColor = Console.ReadLine();
            Console.Write("Id du maître : ");
            int dogMasterId = 1;
            int.TryParse(Console.ReadLine(), out dogMasterId);

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "INSERT INTO dogs (Name, CollarColor, NbrOfLegs, MasterId) OUTPUT INSERTED.Id VALUES (@name, @collarColor, @nbrOfLegs, @masterId)";
            cmd.Parameters.Add(new SqlParameter("@name", dogName));
            cmd.Parameters.Add(new SqlParameter("@collarColor", dogCollarColor));
            cmd.Parameters.Add(new SqlParameter("@nbrOfLegs", dogNbrOfLegs));
            cmd.Parameters.Add(new SqlParameter("@masterId", dogMasterId));

            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    int id = (int) cmd.ExecuteScalar();

                    cmd.Dispose();

                    if (id != 0) Console.WriteLine($"Le chien a été ajouté ! ID : {id}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void EditDog()
        {
            Console.WriteLine("=== Editer un Chien ===\n");

            int dogId = 1;
            Console.Write("ID du chien à éditer : ");
            int.TryParse(Console.ReadLine(), out dogId);

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Name FROM dogs WHERE Id = @id;";
            cmd.Parameters.Add(new SqlParameter("@id", dogId));

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string nomTrouve = (string)cmd.ExecuteScalar();
                    if (nomTrouve != null)
                    {
                        Console.Write("Nom du chien : ");
                        string dogName = Console.ReadLine();
                        Console.Write("Nombre de pattes du chien : ");
                        int dogNbrOfLegs = 4;
                        int.TryParse(Console.ReadLine(), out dogNbrOfLegs);
                        Console.Write("Couleur du collier du chien : ");
                        string dogCollarColor = Console.ReadLine();
                        Console.Write("Id du maître : ");
                        int dogMasterId = 1;
                        int.TryParse(Console.ReadLine(), out dogMasterId);

                        cmd.CommandText = "UPDATE dogs SET Name=@name, CollarColor=@collarColor, NbrOfLegs=@nbrOfLegs, MasterId=@masterId WHERE Id=@id;";
                        cmd.Parameters.Add(new SqlParameter("@name", dogName));
                        cmd.Parameters.Add(new SqlParameter("@collarColor", dogCollarColor));
                        cmd.Parameters.Add(new SqlParameter("@nbrOfLegs", dogNbrOfLegs));
                        cmd.Parameters.Add(new SqlParameter("@masterId", dogMasterId));

                        int rowEdited = cmd.ExecuteNonQuery();
                        if (rowEdited > 0)
                        {
                            Console.WriteLine("Le chien a bien été édité !");
                        }
                        else
                        {
                            Console.WriteLine("ERREUR : Edition impossible !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Il n'y a aucun chien avec cet ID !");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void DeleteDog()
        {
            Console.WriteLine("=== Supprimer un chien ===\n");

            int dogId = 1;
            Console.Write("ID du chien à supprimer : ");
            int.TryParse(Console.ReadLine(), out dogId);

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Name FROM dogs WHERE Id = @id;";
            cmd.Parameters.Add(new SqlParameter("@id", dogId));

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string nomTrouve = (string) cmd.ExecuteScalar();
                    if (nomTrouve != null)
                    {
                        cmd.CommandText = "DELETE FROM dogs WHERE Id = @id;";

                        int nbRows = (int) cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        if (nbRows == 1)
                        {
                            Console.WriteLine("Le chien a bien été supprimé !");
                        }
                        else
                        {
                            Console.WriteLine("ERREUR : La suppression du contact a echoué !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Il n'y a aucun chien avec cet ID !");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
