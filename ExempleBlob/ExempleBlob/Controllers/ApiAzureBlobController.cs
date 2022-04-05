using System;
using ExempleBlob.Services;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("/create/container/{name}")]
        public IActionResult CreateContainer(string name)
        {
            return Ok( new {Result = _azureBlobService.CreateContainer(name)});
        }

        [HttpGet("/getItems/{name}")]
        public IActionResult GetAllItems(string name)
        {
            return Ok(new {Result = _azureBlobService.GetBlobItems(name)});
        }

        [HttpPut("/addFile/{containerName}")]
        public IActionResult PutFile([FromForm] IFormFile file, string containerName)
        {
            try
            {
                return Ok(new {Result = _azureBlobService.UploadFileToBlob(file, containerName)});
            }
            catch (Exception e)
            {
                return Ok(new {Result = e.Message});
            }
        }
    }
}