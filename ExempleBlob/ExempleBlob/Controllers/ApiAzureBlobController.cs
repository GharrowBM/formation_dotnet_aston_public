using ExempleBlob.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExempleBlob.Controllers
{
    [ApiController]
    [Route("ApiBlob")]
    public class ApiAzureBlobController : ControllerBase
    {
        private AzureBlobService _azureBlobService;

        public ApiAzureBlobController(AzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }

        //endPoint pour créer un conteneur de blob
        [HttpGet("create/container/{name}")]
        public IActionResult CreateContainer(string name)
        {
            return Ok( new {Result = _azureBlobService.CreateContainer(name)});
        }
    }
}