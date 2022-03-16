using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04.Classes;

namespace TP04.DAO
{
    internal class ProduitDAO
    {
        public bool Save(Produit produit, IDbConnection connection)
        {
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.CommandText = "INSERT INTO produits (Nom, Prix, Stock) OUTPUT INSERTED.Id VALUES (@nom, @prix, @stock);";
            sqlCommand.Parameters.Add(new SqlParameter("@nom", produit.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@prix", produit.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@stock", produit.Stock));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                produit.Id = (int)sqlCommand.ExecuteScalar();

            }
            sqlCommand.Dispose();
            connection.Close();

            return produit.Id > 0;
        }

        public bool Update(Produit produit, IDbConnection connection, IDbTransaction transaction)
        {
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.CommandText = "UPDATE produits SET Stock = @stock WHERE id = @id;";
            sqlCommand.Transaction = transaction as SqlTransaction;
            sqlCommand.Parameters.Add(new SqlParameter("@stock", produit.Stock));
            sqlCommand.Parameters.Add(new SqlParameter("@id", produit.Id));
            int nbRow = 0;
            if (connection.State == ConnectionState.Open)
            {
                nbRow = sqlCommand.ExecuteNonQuery();
            }
            sqlCommand.Dispose();
            return nbRow == 1;
        }

        public Produit GetById(int id, IDbConnection connection)
        {
            Produit produit = null;
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.CommandText = "SELECT Nom, Prix, Stock FROM produits WHERE id = @id;";
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();
                if (reader.Read())
                {
                    produit = new Produit()
                    {
                        Id = id,
                        Name = reader.GetString(0),
                        Price = reader.GetDecimal(1),
                        Stock = reader.GetInt32(2)
                    };
                }
                reader.Close();
            }
            connection.Close();

            return produit;
        }

        public virtual List<Produit> GetAll(IDbConnection connection)
        {
            List<Produit> produits = new List<Produit>();
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.CommandText = "SELECT Id, Nom, Prix, Stock FROM produits;";

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();
                while (reader.Read())
                {
                    Produit produit = new Produit()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Stock = reader.GetInt32(3)
                    };
                    produits.Add(produit);
                }
                reader.Close();
            }
            connection.Close();

            return produits;
        }
    }
}
