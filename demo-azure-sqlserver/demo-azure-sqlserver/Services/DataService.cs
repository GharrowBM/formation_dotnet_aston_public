using Microsoft.Data.SqlClient;

namespace demo_azure_sqlserver.Services;

public class DataService
{
    private SqlConnection _connection;

    private SqlConnectionStringBuilder builder;
    private SqlCommand _command;
    private SqlDataReader _reader;
    private String _request;
    public DataService()
    {
        builder = new SqlConnectionStringBuilder();
        builder.DataSource = "utopios-aston.database.windows.net";
        builder.UserID = "aston-admin";
        builder.Password = "sqlserver123.";
        builder.InitialCatalog = "ihab";
    }
    
    public SqlConnection NewConnection
    {
        get => new SqlConnection(builder.ConnectionString);
    }

    public bool InsertInToPersonne(string name)
    {
        bool result = false;
        _request = "INSERT INTO personne (nom) values (@nom)";
        _connection = NewConnection;
        _command = new SqlCommand(_request, _connection);
        _command.Parameters.Add(new SqlParameter("@nom", name));
        _connection.Open();
        result = _command.ExecuteNonQuery() > 0;
        _command.Dispose();
        _connection.Close();
        return result;
    }

    public List<Personne> GetPersonnes()
    {
        List<Personne> results = new List<Personne>();
        _request = "SELECT * FROM personne";
        _connection = NewConnection;
        _command = new SqlCommand(_request, _connection);
        _connection.Open();
        _reader = _command.ExecuteReader();
        while (_reader.Read())
        {
            results.Add(new Personne(_reader.GetInt32(0), _reader.GetString(1)));
        }
        _reader.Close();
        _command.Dispose();
        _connection.Close();
        return results;
    }
}

public record Personne(int Id, string Nom);