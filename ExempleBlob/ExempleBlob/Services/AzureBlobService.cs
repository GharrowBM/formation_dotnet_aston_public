using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ExempleBlob.Services
{
    public class AzureBlobService
    {
        private string connectionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosaston;AccountKey=YinX6bXgRmDmvRq3nN7P+uHAY8kr4RZj9tkvkq/LB6IQ2xGnh6FNoJYlofL/rhflVPfRZ3cLbnlLUuvM44NgXw==;EndpointSuffix=core.windows.net";

        private BlobServiceClient blobServiceClient;

        public AzureBlobService()
        {
            blobServiceClient = new BlobServiceClient(connectionString);
        }

        public bool CreateContainer(string name)
        {
            BlobContainerClient container = blobServiceClient.CreateBlobContainer(name, PublicAccessType.Blob);
            return container != null;
        }

        
        public BlobContainerClient GetContainer(string name)
        {
            BlobContainerClient container = blobServiceClient.GetBlobContainerClient(name);
            return container;
        }

        public List<BlobItem> GetBlobItems(string name)
        {
            List<BlobItem> items = new List<BlobItem>();
            BlobContainerClient containerClient = GetContainer(name);
            if (containerClient != null)
            {
                items = containerClient.GetBlobs().ToList();
            }
            return items;
        }
        
    }
}