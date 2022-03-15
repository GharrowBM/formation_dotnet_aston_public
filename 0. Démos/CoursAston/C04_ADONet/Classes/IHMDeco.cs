using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04_ADONet.Classes
{
    internal class IHMDeco
    {
        private SqlConnection _sqlConnection;
        private SqlDataAdapter _dogAdapter;
        private SqlDataAdapter _masterAdapter;
        private DataSet _dogDataset;
        private DataRelation masterId_IdMaster;

        public IHMDeco(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _dogAdapter = new SqlDataAdapter();
            _masterAdapter = new SqlDataAdapter();
            _dogDataset = new DataSet("dogs");
            _dogDataset.Tables.Add(new DataTable("dogs"));
            _dogDataset.Tables.Add(new DataTable("masters"));

            LoadDatas();
        }

        public void Run()
        {
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
                        SaveDatas();
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

        private void SeeDogs()
        {
            Console.WriteLine("=== Liste des Chiens ===\n");

            foreach(DataRow row in _dogDataset.Tables["dogs"].AsEnumerable())
            {
                if (row.RowState != DataRowState.Deleted) Console.WriteLine($"{row.Field<int>("Id")}. Nom : {row.Field<string>("Name")}, Couleur du collier : {row.Field<string>("CollarColor")}, Nombre de pattes : {row.Field<int>("NbrOfLegs")}, Maître : {row.GetParentRow(masterId_IdMaster).Field<string>("Firstname")} {row.GetParentRow(masterId_IdMaster).Field<string>("Lastname")}");
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

            _dogDataset.Tables["dogs"].Rows.Add(null, dogName, dogCollarColor, dogNbrOfLegs, dogMasterId);

            Console.WriteLine($"Chien ajouté avec succès. Id : {_dogDataset.Tables["dogs"].Rows.Count}");
        }

        private void EditDog()
        {
            Console.WriteLine("=== Editer un Chien ===\n");

            int dogId = 1;
            Console.Write("ID du chien à éditer : ");
            int.TryParse(Console.ReadLine(), out dogId);

            DataRow found = _dogDataset.Tables["dogs"].Select($"Id = {dogId}").FirstOrDefault();

            if(found == null)
            {
                Console.WriteLine("Aucun chien avec cet ID !");
            }
            else
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

                found["Name"] = dogName;
                found["CollarColor"] = dogCollarColor;
                found["NbrOfLegs"] = dogNbrOfLegs;
                found["MasterId"] = dogMasterId;

                Console.WriteLine("Chien modifié avec succès");
            }
        }

        private void DeleteDog()
        {
            Console.WriteLine("=== Supprimer un chien ===\n");

            int dogId = 1;
            Console.Write("ID du chien à supprimer : ");
            int.TryParse(Console.ReadLine(), out dogId);

            DataRow found = _dogDataset.Tables["dogs"].Select($"Id = {dogId}").FirstOrDefault();

            if (found == null)
            {
                Console.WriteLine("Aucun chien avec cet ID !");
            }
            else
            {
                found.Delete();

                Console.WriteLine("Chien supprimé avec succès");
            }
        }

        private void LoadDatas()
        {
            try
            {
                Console.WriteLine("Ouverture de la connection...");

                _sqlConnection.Open();
                Console.WriteLine("Connection ouverte !");

                SqlCommand cmd = _sqlConnection.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, CollarColor, NbrOfLegs, MasterId FROM dogs;";
                _dogAdapter.SelectCommand = cmd;
                _dogAdapter.Fill(_dogDataset.Tables["dogs"]);
                _dogAdapter.TableMappings.Add("dogs", "dogs");
                _dogDataset.Tables["dogs"].Columns["Id"].AutoIncrement = true;
                _dogDataset.Tables["dogs"].Columns["Id"].AutoIncrementSeed = _dogDataset.Tables["dogs"].Rows.Count + 1;
                _dogDataset.Tables["dogs"].Columns["Id"].AutoIncrementStep = 1;

                SqlCommand cmd2 = _sqlConnection.CreateCommand();
                cmd2.CommandText = "SELECT Id, Firstname, Lastname FROM masters;";
                _masterAdapter.SelectCommand = cmd2;
                _masterAdapter.Fill(_dogDataset.Tables["masters"]);
                _masterAdapter.TableMappings.Add("masters", "masters");
                _dogDataset.Tables["masters"].Columns["Id"].AutoIncrement = true;
                _dogDataset.Tables["masters"].Columns["Id"].AutoIncrementSeed = _dogDataset.Tables["masters"].Rows.Count + 1;
                _dogDataset.Tables["masters"].Columns["Id"].AutoIncrementStep = 1;

                Console.WriteLine("Création des relations...");

                DataColumn masterId = _dogDataset.Tables["dogs"].Columns["MasterId"];
                DataColumn idMaster = _dogDataset.Tables["masters"].Columns["Id"];
                masterId_IdMaster = new DataRelation("MasterId_IdMaster", idMaster, masterId);
                _dogDataset.Relations.Add(masterId_IdMaster);

                Console.WriteLine("Relations créées !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Fermeture de la connection...");

                _sqlConnection.Close();
                Console.WriteLine("Connection fermée !");
            }
        }

        private void SaveDatas()
        {
            SqlCommand insertDog = new SqlCommand("INSERT INTO dogs (Name, CollarColor, NbrOfLegs, MasterId) VALUES (@name, @collarColor, @nbrOfLegs, @masterId);", _sqlConnection);
            insertDog.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            insertDog.Parameters.Add("@collarColor", SqlDbType.NVarChar, 50, "CollarColor");
            insertDog.Parameters.Add("@nbrOfLegs", SqlDbType.Int, 11, "NbrOfLegs");
            insertDog.Parameters.Add("@masterId", SqlDbType.Int, 11, "MasterId");
            
            SqlCommand updateDog = new SqlCommand("UPDATE dogs SET Name = @name, CollarColor = @collarColor, NbrOfLegs = @nbrOfLegs, MasterId = @masterId WHERE Id = @id;", _sqlConnection);
            updateDog.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            updateDog.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            updateDog.Parameters.Add("@collarColor", SqlDbType.NVarChar, 50, "CollarColor");
            updateDog.Parameters.Add("@nbrOfLegs", SqlDbType.Int, 11, "NbrOfLegs");
            updateDog.Parameters.Add("@masterId", SqlDbType.Int, 11, "MasterId");

            SqlCommand deleteDog = new SqlCommand("DELETE FROM dogs WHERE Id = @id;", _sqlConnection);
            deleteDog.Parameters.Add("@id", SqlDbType.Int, 11, "Id");

            _dogAdapter.InsertCommand = insertDog;
            _dogAdapter.UpdateCommand = updateDog;
            _dogAdapter.DeleteCommand = deleteDog;

            _dogAdapter.Update(_dogDataset, "dogs");

            SqlCommand insertMaster = new SqlCommand("INSERT INTO masers (Firstname, Lastname) VALUES (@firstname, @lastname);", _sqlConnection);
            insertMaster.Parameters.Add("@firstname", SqlDbType.NVarChar, 50, "Firstname");
            insertMaster.Parameters.Add("@lastname", SqlDbType.NVarChar, 50, "Lastname");

            SqlCommand updateMaster = new SqlCommand("UPDATE masters SET Firstname = @firstname, Lastname = @lastname WHERE Id = @id;", _sqlConnection);
            updateMaster.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            updateMaster.Parameters.Add("@firstname", SqlDbType.NVarChar, 50, "Firstname");
            updateMaster.Parameters.Add("@lastname", SqlDbType.NVarChar, 50, "Lastname");

            SqlCommand deleteMaster = new SqlCommand("DELETE FROM masters WHERE Id = @id;", _sqlConnection);
            deleteMaster.Parameters.Add("@id", SqlDbType.Int, 11, "Id");

            _masterAdapter.InsertCommand = insertMaster;
            _masterAdapter.UpdateCommand = updateMaster;
            _masterAdapter.DeleteCommand = deleteMaster;

            _masterAdapter.Update(_dogDataset, "masters");
        }
    }
}
