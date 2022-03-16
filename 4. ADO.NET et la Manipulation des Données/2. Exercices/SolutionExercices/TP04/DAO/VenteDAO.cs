using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04.Classes;
using TP04.Interfaces;

namespace TP04.DAO
{
    internal class VenteDAO
    {
        public bool Save(Vente vente, IDbConnection connection, IDbTransaction transaction)
        {
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.Transaction = transaction as SqlTransaction;
            sqlCommand.CommandText = "INSERT INTO ventes (Date, Etat, Type_Paiement, Total, Monnaie) OUTPUT INSERTED.Id VALUES (@date, @etat, @type_paiement, @total, @monnaie);";
            sqlCommand.Parameters.Add(new SqlParameter("@date", vente.Paiement.DatePaiement));
            sqlCommand.Parameters.Add(new SqlParameter("@etat", vente.IsComplete));
            sqlCommand.Parameters.Add(new SqlParameter("@type_paiement", vente.Paiement.ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@total", vente.Total));
            sqlCommand.Parameters.Add(new SqlParameter("@monnaie", vente.Paiement is PaiementEspece ? ((PaiementEspece)vente.Paiement).Monnaie : 0));

            if (connection.State == ConnectionState.Open)
            {
                vente.Id = (int)sqlCommand.ExecuteScalar();
                sqlCommand.Dispose();
            }

            return vente.Id > 0;
        }

        public bool SaveVenteProduits(Vente vente, Produit produit, IDbConnection connection, IDbTransaction transaction)
        {
            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.Transaction = transaction as SqlTransaction;
            sqlCommand.CommandText = "INSERT INTO ventes_produits (VenteId, ProduitId) VALUES (@venteId, @produitId);";
            sqlCommand.Parameters.Add(new SqlParameter("@venteId", vente.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@produitId", produit.Id));

            int nbRows = 0;
            if (connection.State == ConnectionState.Open)
            {
                nbRows = sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }

            return nbRows == 1;
        }

        public List<Vente> RecupererVentes(IDbConnection connection)
        {
            List<Vente> ventes = new List<Vente>();

            SqlCommand sqlCommand = (connection as SqlConnection).CreateCommand();
            sqlCommand.CommandText = "SELECT Id, Date, Etat, Type_Paiement, Total, Monnaie FROM ventes;";

            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();

                while (reader.Read())
                {
                    Vente vente = new Vente()
                    {
                        Id = reader.GetInt32(0),
                        IsComplete = reader.GetBoolean(2),
                        Total = reader.GetDecimal(4),
                        Paiement = reader.GetString(3) == "CB" ? new PaiementCB() { DatePaiement = reader.GetDateTime(1) } : reader.GetString(3) == "Especes" ? new PaiementEspece() { DatePaiement = reader.GetDateTime(1), Monnaie = reader.GetDecimal(5) } : null
                    };

                    SqlCommand sqlCommand2 = (connection as SqlConnection).CreateCommand();
                    sqlCommand.CommandText = "SELECT produits.Id, Nom, Prix, Stock, FROM produits JOIN ventes_produits ON produits.Id = ventes_produits.ProduitId WHERE venteId = @id;";
                    sqlCommand2.Parameters.Add(new SqlParameter("@id", vente.Id));
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                    sqlCommand2.Dispose();

                    while (reader2.Read())
                    {
                        Produit produit = new Produit()
                        {
                            Id = reader2.GetInt32(0),
                            Name = reader2.GetString(1),
                            Price = reader2.GetDecimal(2),
                            Stock = reader2.GetInt32(3)
                        };
                        vente.Produits.Add(produit);
                    }
                    reader2.Close();

                    ventes.Add(vente);
                }
                reader.Close();
            }
            connection.Close();

            return ventes;
        }
    }
}
