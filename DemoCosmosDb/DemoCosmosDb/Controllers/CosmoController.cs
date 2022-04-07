using DemoCosmosDb.Models;
using DemoCosmosDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoCosmosDb.Controllers;

[ApiController]
[Route("/cosmo")]
public class CosmoController : ControllerBase
{
    private CosmoService _cosmoService;

    public CosmoController(CosmoService cosmoService)
    {
        _cosmoService = cosmoService;
    }
    [HttpGet("/create/db/{name}")]
    public IActionResult CreateCosmoDb(string name)
    {
        _cosmoService.CreateDataBase(name);
        return Ok();
    }
    
    [HttpGet("/db/{dbName}/create/container/{containerName}")]
    public IActionResult CreateCosmoContainer(string dbName, string containerName)
    {
        _cosmoService.CreateContainer(dbName, containerName);
        return Ok();
    }
    
    
    [HttpPut("/db/{dbName}/container/{containerName}/item")]
    public async Task<IActionResult> CreateCosmoItem(string dbName, string containerName, [FromBody] Person person)
    {
        return Ok(new {Result = await _cosmoService.CreatePerson(person, dbName, containerName)});
    }
    
    //Récupération 
    [HttpGet("/db/{dbName}/container/{containerName}/persons")]
    public IActionResult GetItems(string dbName, string containerName)
    {
        return Ok(new {Results = _cosmoService.GetPersons(dbName, containerName)});
    }
    
    [HttpGet("/db/{dbName}/container/{containerName}/persons/{id}")]
    public IActionResult GetItem(string dbName, string containerName, string id)
    {
        return Ok(new {Results = _cosmoService.GetPerson(id, dbName, containerName)});
    }
    
    //Suppression
    [HttpDelete("/db/{dbName}/container/{containerName}/persons/{id}")]
    public IActionResult DeleteItem(string dbName, string containerName, string id)
    {
        _cosmoService.DeletePerson(id, dbName, containerName);
        return Ok();
    }
    //Mise à jour
    
    [HttpPut("/db/{dbName}/container/{containerName}/persons/{id}")]
    public IActionResult UpdateItem(string dbName, string containerName, string id, [FromBody] Person person)
    {
        _cosmoService.UpdatePerson(id, person, dbName, containerName);
        return Ok();
    }
    
}