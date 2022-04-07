using System.Runtime.CompilerServices;
using DemoCosmosDb.Models;
using Microsoft.Azure.Cosmos;

namespace DemoCosmosDb.Services;

public class CosmoService
{
    private CosmosClient _cosmosClient;
    private string accountName = "https://aston.documents.azure.com:443/";
    private string accountKey = "7WfVe1bGYmlDc0j9n6ED0rfri1x2UWTS1KnNrTgyfweOfzeampRAfAR9BnDkU7VPJTC2rXuSQ5t7ufch3DhBsg==";

    public CosmoService()
    {
        _cosmosClient = new CosmosClient(accountName, accountKey);
    }

    public Database GetDataBase(string dbName)
    {
        return _cosmosClient.GetDatabase(dbName);
    }

    public async void CreateDataBase(string name)
    {
        await _cosmosClient.CreateDatabaseIfNotExistsAsync(name);
    }

    public async void CreateContainer(string dbName, string containerName)
    {
        Database database = GetDataBase(dbName);
        await database.CreateContainerIfNotExistsAsync(containerName, "/id");
    }

    public Container GetContainer(string dbName, string containerName)
    {
        return GetDataBase(dbName).GetContainer(containerName);
    }

    public async Task<ItemResponse<Person>> CreatePerson(Person person, string dbName, string containerName)
    {
        Container container = GetContainer(dbName, containerName);
        return await container.CreateItemAsync<Person>(person, new PartitionKey(person.Id));
    }

    public async void DeletePerson(string id, string dbName, string containerName)
    {
        Container container = GetContainer(dbName, containerName);
        await container.DeleteItemAsync<Person>(id, new PartitionKey(id));
    }

    public async void UpdatePerson(string id, Person person, string dbName, string containerName)
    {
        Container container = GetContainer(dbName, containerName);
        await container.UpsertItemAsync(person, new PartitionKey(id));
    }

    public async Task<Person> GetPerson(string id, string dbName, string containerName)
    {
        Container container = GetContainer(dbName, containerName);
        ItemResponse<Person> read = await container.ReadItemAsync<Person>(id, new PartitionKey(id));
        return read.Resource;
    }

    public async Task<IEnumerable<Person>> GetPersons(string dbName, string containerName)
    {
        List<Person> persons = new List<Person>();
        Container container = GetContainer(dbName, containerName);
        FeedIterator<Person> query = container.GetItemQueryIterator<Person>(new QueryDefinition("SELECT c.id, c.first_name, c.last_name FROM c"));
        while (query.HasMoreResults)
        {
            persons.AddRange((await query.ReadNextAsync()).ToList());
        }
        
        return persons;
    }







}