using DemoUsingAzureVault.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoUsingAzureVault.Controllers;

[ApiController]
[Route("secret")]
public class SecretController : ControllerBase
{
    private SecretService _secretService;

    public SecretController(SecretService secretService)
    {
        _secretService = secretService;
    }

    [HttpPut("{name}")]
    public IActionResult Put(string name, [FromForm] string value)
    {
        try
        {
            _secretService.SetTokenSecret(name, value);
            return Ok();
        }
        catch (Exception ex)
        {
            return Ok(ex);
        }
            
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        try
        {
            
            return Ok(new {result = _secretService.GetTokenSecret(name)});
        }
        catch (Exception ex)
        {
            return Ok(new {result = ex});
        }
        
    }
}