using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Classes;

namespace TP03.Data
{
    internal class CaisseDataSet
    {
        private SqlConnection _sqlConnection;
        private SqlDataAdapter _adapter;
        private DataSet _dataSet;

        public CaisseDataSet(IDbConnection connection)
        {
            _sqlConnection = connection as SqlConnection;
            _adapter = new SqlDataAdapter();
            _dataSet = new DataSet("caisse");
            _dataSet.Tables.Add(new DataTable("produits"));
            _dataSet.Tables.Add(new DataTable("ventes"));
            _dataSet.Tables.Add(new DataTable("ventes_produits"));

            FillDataSets();
        }

        public void FillDataSets()
        {
            Console.WriteLine("Ouverture de la connection...");

            _sqlConnection.Open();
            Console.WriteLine("Connection ouverte !");

            SqlCommand cmd = _sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nom, Prix, Stock FROM produits;";
            SqlCommand cmd2 = _sqlConnection.CreateCommand();
            cmd2.CommandText = "SELECT Id, Date, Etat, Type_Paiement, Total, Monnaie FROM ventes;";
            SqlCommand cmd3 = _sqlConnection.CreateCommand();
            cmd3.CommandText = "SELECT Id, VenteId, ProduitId FROM ventes_produits;";


            _adapter.SelectCommand = cmd;
            _adapter.Fill(_dataSet.Tables["produits"]);
            _adapter.TableMappings.Add("produits", "produits");

            _adapter.SelectCommand = cmd2;
            _adapter.Fill(_dataSet.Tables["ventes"]);
            _adapter.TableMappings.Add("ventes", "ventes");

            _adapter.SelectCommand = cmd3;
            _adapter.Fill(_dataSet.Tables["ventes_produits"]);
            _adapter.TableMappings.Add("ventes_produits", "ventes_produits");

            Console.WriteLine("Fermeture de la connection...");

            _sqlConnection.Close();
            Console.WriteLine("Connection fermée !");

            Console.WriteLine("Création des relations...");

            DataColumn venteId = _dataSet.Tables["ventes_produits"].Columns["VenteId"];
            DataColumn produitId = _dataSet.Tables["ventes_produits"].Columns["ProduitId"]; 
            DataColumn idVente = _dataSet.Tables["ventes"].Columns["Id"];
            DataColumn idProduit = _dataSet.Tables["produits"].Columns["Id"];

            DataRelation venteId_idVente = new DataRelation("VenteId_IdVente", idVente, venteId);
            DataRelation produitId_idProduit = new DataRelation("ProduitId_IdProduit", idProduit, produitId);
            _dataSet.Relations.Add(venteId_idVente);
            _dataSet.Relations.Add(produitId_idProduit);

            Console.WriteLine("Relations créées !");

        }

        public void SaveDatas()
        {
            SqlCommand insertProduit = new SqlCommand("INSERT INTO produits (Nom, Prix, Stock) VALUES (@nom, @prix, @stock);", _sqlConnection);
            insertProduit.Parameters.Add("@nom", SqlDbType.NVarChar, 50, "Nom");
            insertProduit.Parameters.Add("@prix", SqlDbType.Decimal, 18, "Prix");
            insertProduit.Parameters.Add("@stock", SqlDbType.Int, 11, "Stock");

            SqlCommand insertVente = new SqlCommand("INSERT INTO ventes (Date, Etat, Type_Paiement, Total, Monnaie VALUES (@date, @etat, @type_paiement, @total, @monnaie);", _sqlConnection);
            insertVente.Parameters.Add("@date", SqlDbType.DateTime, 0, "Date");
            insertVente.Parameters.Add("@etat", SqlDbType.Bit, 1, "Etat");
            insertVente.Parameters.Add("@type_paiement", SqlDbType.NVarChar, 10, "Type_Paiement");
            insertVente.Parameters.Add("@total", SqlDbType.Decimal, 18, "Total");
            insertVente.Parameters.Add("@monnaie", SqlDbType.Decimal, 18, "Monnaie");

            SqlCommand insertVente_Produit = new SqlCommand("INSERT INTO ventes_produits (VenteId, ProduitId) VALUES (@venteId, @produitId);", _sqlConnection);
            insertVente_Produit.Parameters.Add("@venteId", SqlDbType.Int, 11, "VenteId");
            insertVente_Produit.Parameters.Add("@produitId", SqlDbType.Int, 11, "ProduitId");

            SqlCommand updateProduit = new SqlCommand("UPDATE produits SET Nom = @nom, Prix = @prix, Stock = @stock WHERE Id = @id;", _sqlConnection);
            updateProduit.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            updateProduit.Parameters.Add("@nom", SqlDbType.NVarChar, 50, "Nom");
            updateProduit.Parameters.Add("@prix", SqlDbType.Decimal, 18, "Prix");
            updateProduit.Parameters.Add("@stock", SqlDbType.Int, 11, "Stock");

            SqlCommand updateVente = new SqlCommand("UPDATE ventes SET Date = @date, Etat = @etat, Type_Paiement = @type_paiement, Total = @total, Monnaie = @monnaie WHERE Id = @id;", _sqlConnection);
            updateVente.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            updateVente.Parameters.Add("@date", SqlDbType.DateTime, 0, "Date");
            updateVente.Parameters.Add("@etat", SqlDbType.Bit, 1, "Etat");
            updateVente.Parameters.Add("@type_paiement", SqlDbType.NVarChar, 10, "Type_Paiement");
            updateVente.Parameters.Add("@total", SqlDbType.Decimal, 18, "Total");
            updateVente.Parameters.Add("@monnaie", SqlDbType.Decimal, 18, "Monnaie");

            SqlCommand updateVente_Produit = new SqlCommand("UPDATE ventes_produits SET VenteId = @venteId, ProduitId = @produitId WHERE Id = @id;", _sqlConnection);
            updateVente_Produit.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            updateVente_Produit.Parameters.Add("@venteId", SqlDbType.Int, 11, "VenteId");
            updateVente_Produit.Parameters.Add("@produitId", SqlDbType.Int, 11, "ProduitId");

            SqlCommand deleteProduit = new SqlCommand("DELETE FROM produits WHERE Id = @id;", _sqlConnection);
            deleteProduit.Parameters.Add("@id", SqlDbType.Int, 11, "Id");

            SqlCommand deleteVente = new SqlCommand("DELETE FROM ventes WHERE Id = @id;", _sqlConnection);
            deleteVente.Parameters.Add("@id", SqlDbType.Int, 11, "Id");

            SqlCommand deleteVente_Produit = new SqlCommand("DELETE FROM ventes_produits WHERE Id = @id;", _sqlConnection);
            deleteVente_Produit.Parameters.Add("@id", SqlDbType.Int, 11, "Id");

            _adapter.InsertCommand = insertProduit;
            _adapter.UpdateCommand = updateProduit;
            _adapter.DeleteCommand = deleteProduit;

            _adapter.Update(_dataSet, "produits");

            _adapter.InsertCommand = insertVente;
            _adapter.UpdateCommand = updateVente;
            _adapter.DeleteCommand = deleteVente;

            _adapter.Update(_dataSet, "ventes");

            _adapter.InsertCommand = insertVente_Produit;
            _adapter.UpdateCommand = updateVente_Produit;
            _adapter.DeleteCommand = deleteVente_Produit;

            _adapter.Update(_dataSet, "ventes_produits");

        }

        public List<Produit> GetProducts()
        {
            List<Produit> products = new List<Produit>();

            products = (from row in _dataSet.Tables["produits"].AsEnumerable() select new Produit()
            {
                Id = row.Field<int>("Id"),
                Name = row.Field<string>("Nom"),
                Price = row.Field<decimal>("Prix"),
                Stock = row.Field<int>("Stock")
            }).ToList();

            return products;
        }

        public Produit GetProductById(int id)
        {
            Produit product = null;

            product = (from row in _dataSet.Tables["produits"].AsEnumerable()
                       where row.Field<int>("Id") == id
                       select new Produit()
                       {
                           Id = row.Field<int>("Id"),
                           Name = row.Field<string>("Nom"),
                           Price = row.Field<decimal>("Prix"),
                           Stock = row.Field<int>("Stock")
                       }).FirstOrDefault();

            return product;
        }


        public bool AddProduct(Produit product)
        {
            DataRow newRow = _dataSet.Tables["produits"].Rows.Add(_dataSet.Tables["produits"].Rows.Count + 1,product.Name, product.Price, product.Stock);

            if (newRow != null)
            {
                return true;
            }

            return false;
        }

        public Produit UpdateProduct(Produit product)
        {
            Produit updatedProduct = null;

            var foundRow = _dataSet.Tables["produits"].Select($"Id = {product.Id}").FirstOrDefault();

            if(foundRow != null)
            {
                foundRow["Id"] = product.Id;
                foundRow["Nom"] = product.Name;
                foundRow["Prix"] = product.Price;
                foundRow["Stock"] = product.Stock;

                updatedProduct = new Produit()
                {
                    Id = foundRow.Field<int>("Id"),
                    Name = foundRow.Field<string>("Nom"),
                    Price = foundRow.Field<decimal>("Prix"),
                    Stock = foundRow.Field<int>("Stock")
                };
            }

            return updatedProduct;
        }

        public bool AddSale(Vente sale)
        {
            DataRow newRow = _dataSet.Tables["ventes"].Rows.Add(_dataSet.Tables["ventes"].Rows.Count + 1, sale.Paiement.DatePaiement, sale.IsComplete, sale.Paiement.ToString(), sale.Total, sale.Paiement is PaiementEspece ? ((PaiementEspece)sale.Paiement).Monnaie : 0);

            if (newRow != null)
            {
                return true;
            }

            return false;
        }

        public bool AddSaleProducts(Vente sale, Produit product)
        {
            DataRow newRow = _dataSet.Tables["ventes_produits"].Rows.Add(_dataSet.Tables["ventes_produits"].Rows.Count + 1, sale.Id, product.Id);

            if (newRow != null)
            {
                return true;
            }

            return false;
        }






    }
}
