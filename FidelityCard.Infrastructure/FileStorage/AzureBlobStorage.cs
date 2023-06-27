using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Infrastructure.FileStorage;
public class AzureBlobStorage : IStorage
{
	private readonly BlobServiceClient? _blobServiceClient;

	public AzureBlobStorage(IConfiguration configuration)
	{
		var azureBlobStorageConnectionString = configuration.GetConnectionString("AzureBlobStorageConnectionString");
		if (!string.IsNullOrWhiteSpace(azureBlobStorageConnectionString))
			_blobServiceClient = new BlobServiceClient(azureBlobStorageConnectionString);
	}

	public void DeleteFile(string container, string fileName)
	{
		try
		{
			if (_blobServiceClient == null) return;

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

	public string? DownloadBase64FileContent(string container, string fileName)
	{
		try
		{
			var file = DownloadFile(container, fileName);

			if (file == null) return null;

			using var ms = new MemoryStream();
			file.CopyTo(ms);
			return Convert.ToBase64String(ms.ToArray());
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public Stream? DownloadFile(string container, string fileName)
	{
		try
		{
			if (_blobServiceClient == null) return null;

			var containerClient = _blobServiceClient.GetBlobContainerClient(container);
			var blobClient = containerClient.GetBlobClient(fileName);
			var response = blobClient.DownloadStreaming();

			return response.Value.Content;
		}
		catch (Exception e)
		{
			return null;
		}
	}

	public async Task<string?> UploadFile(string container, Stream content, string originalFileName)
	{
		try
		{
			var fileExtension = Path.GetExtension(originalFileName).Replace(".", "");
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
			return null;
		}
	}
}