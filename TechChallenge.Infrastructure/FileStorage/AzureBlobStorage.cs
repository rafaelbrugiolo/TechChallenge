﻿using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Infrastructure.FileStorage;
public class AzureBlobStorage : IStorage
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureBlobStorage(IConfiguration configuration)
    {
        var azureBlobStorageConnectionString = configuration.GetConnectionString("AzureBlobStorageConnectionString");
        _blobServiceClient = new BlobServiceClient(azureBlobStorageConnectionString);
    }

    public void DeleteFile(string container, string fileName)
    {
        try
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            var blobClient = containerClient.GetBlobClient(fileName);
            if (blobClient is not null)
                blobClient.Delete();
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public Stream DownloadFile(string container, string fileName)
    {
        try
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            var blobClient = containerClient.GetBlobClient(fileName);
            var response = blobClient.DownloadStreaming();

            return response.Value.Content;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<string> UploadFile(string container, Stream content, string fileExtension)
    {
        try
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(container);
            containerClient.CreateIfNotExists();

            var fileName = Guid.NewGuid().ToString();
            var fullFileName = string.Format($"{fileName}.{fileExtension}", fileName, fileExtension);
            
            var blobClient = containerClient.GetBlobClient(fullFileName);
            await blobClient.UploadAsync(content, true);

            return fullFileName;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}