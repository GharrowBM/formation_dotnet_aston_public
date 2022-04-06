using demo_azure_sqlserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo_azure_sqlserver.Controllers;

[ApiController]
[Route("personne")]
public class PersonneController : ControllerBase
{
    private DataService _dataService;
    public PersonneController(DataService dataService)
    {
        _dataService = dataService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_dataService.GetPersonnes());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Personne personne)
    {
        return Ok(_dataService.InsertInToPersonne(personne.Nom));
    }
}