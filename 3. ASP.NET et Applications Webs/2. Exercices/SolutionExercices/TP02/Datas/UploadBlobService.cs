using Azure.Identity;
using Azure.Storage.Blobs;

namespace TP02.Datas;

public class UploadBlobService : IUploadService
{
    private BlobServiceClient _blobServiceClient;
    private const string baseUrl = "https://utopiosaston.blob.core.windows.net/images";

    public UploadBlobService()
    {
        _blobServiceClient = new BlobServiceClient(new Uri("https://utopiosaston.blob.core.windows.net/images"), new DefaultAzureCredential());
    }
    public string Upload(IFormFile formFile)
    {
        BlobContainerClient containerClient = GetContainer("images");
        if (containerClient != null)
        {
            BlobClient blobClient = containerClient.GetBlobClient(formFile.FileName);
            using MemoryStream stream = new MemoryStream();
            formFile.CopyTo(stream);
            stream.Position = 0;
            var response = blobClient.Upload(stream);
            stream.Dispose();
            return $"{baseUrl}/{formFile.FileName}";
        }
        return $"{baseUrl}/avatar.png";
    }
    
    public BlobContainerClient GetContainer(string name)
    {
        BlobContainerClient container = _blobServiceClient.GetBlobContainerClient(name);
        return container;
    }
    
    
}