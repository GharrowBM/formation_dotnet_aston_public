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

    [HttpPut("/{name}")]
    public IActionResult Put(string name, [FromForm] string value)
    {
        _secretService.SetTokenSecret(name, value);
        return Ok();
    }

    [HttpGet("/{name}")]
    public IActionResult Get(string name)
    {
        return Ok(_secretService.GetTokenSecret(name));
    }
}