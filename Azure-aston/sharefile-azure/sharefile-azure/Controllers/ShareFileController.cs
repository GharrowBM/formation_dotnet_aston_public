using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sharefile_azure.Controllers
{
    [ApiController]
    [Route("/sharefile")]
    public class ShareFileController : ControllerBase
    {
        private string connexionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosaston;AccountKey=YinX6bXgRmDmvRq3nN7P+uHAY8kr4RZj9tkvkq/LB6IQ2xGnh6FNoJYlofL/rhflVPfRZ3cLbnlLUuvM44NgXw==;EndpointSuffix=core.windows.net";
        private string shareName = "aston";
        [HttpGet("create/{name}")]
        public async Task<IActionResult> CreateShareFile(string name)
        {
            ShareClient shareClient = new ShareClient(connexionString, name);
            Response<ShareInfo> response  = await shareClient.CreateIfNotExistsAsync();
            return Ok(new {Message = response == null ? "existe déja" : "crée"});
        }
        
        [HttpGet("exist/{name}")]
        public async Task<IActionResult> IfExist(string name)
        {
            ShareClient shareClient = new ShareClient(connexionString, name);
            Response<bool> response  = await shareClient.ExistsAsync();
            return Ok(new {Message = response ? "existe" : "N'existe pas"});
        }

        [HttpGet("getfile/{name}")]
        public async Task<IActionResult> GetFile(string name)
        {
            ShareClient shareClient = new ShareClient(connexionString, shareName);
            //Récuperer le dossier, un client pour accéder à un dossier sur notre sharefile 
            ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient("toto");
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient file = directoryClient.GetFileClient(name);
            
            if (await file.ExistsAsync())
            {
                return Ok(new {Message = file.Uri});
            }
            return NotFound();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile fileToUpload)
        {
            ShareClient shareClient = new ShareClient(connexionString, shareName);
            ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient("toto");
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient file = directoryClient.GetFileClient(fileToUpload.FileName);
            using Stream stream = new MemoryStream();
            await fileToUpload.CopyToAsync(stream);
            await file.CreateAsync(stream.Length);
            stream.Position = 0;
            await file.UploadRangeAsync(new HttpRange(0, stream.Length),stream);
            stream.Dispose();
            return Ok();
        }
     }
}