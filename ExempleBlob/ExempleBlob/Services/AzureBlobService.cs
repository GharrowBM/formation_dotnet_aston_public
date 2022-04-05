using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace ExempleBlob.Services
{
    public class AzureBlobService
    {
        
        private BlobServiceClient blobServiceClient;

        public AzureBlobService()
        {
            blobServiceClient = new BlobServiceClient(new Uri("https://utopiosaston.blob.core.windows.net/images"), new DefaultAzureCredential());
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

        public bool UploadFileToBlob(IFormFile file, string containerName)
        {
            BlobContainerClient containerClient = GetContainer(containerName);
            if (containerClient != null)
            {
                BlobClient blobClient = containerClient.GetBlobClient(file.FileName);
                using MemoryStream stream = new MemoryStream();
                file.CopyTo(stream);
                stream.Position = 0;
                var response = blobClient.Upload(stream);
                stream.Dispose();
                return response != null;
            }
            return false;
        }
    }
}