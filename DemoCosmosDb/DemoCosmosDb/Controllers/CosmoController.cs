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
    
    //Suppression
    
    //Mise à jour
    
}