using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.ExternalServices
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
        Task DeleteFileAsync(string fileUrl);
        Task<Stream> DownloadFileAsync(string fileUrl);
    }

    public class FileStorageService : IFileStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _storageType;
        private readonly string _localStoragePath;
        private readonly BlobServiceClient? _blobServiceClient;
        private readonly string _containerName;

        public FileStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _storageType = _configuration["FileStorage:Type"] ?? "Local";
            _localStoragePath = _configuration["FileStorage:LocalPath"] ?? "wwwroot/uploads";
            _containerName = _configuration["FileStorage:ContainerName"] ?? "learnedge-files";

            if (_storageType.Equals("Azure", StringComparison.OrdinalIgnoreCase))
            {
                var connectionString = _configuration["AzureStorage:ConnectionString"] ?? 
                    throw new InvalidOperationException("Azure Storage Connection String not configured");
                _blobServiceClient = new BlobServiceClient(connectionString);
                InitializeContainer();
            }
            else
            {
                // Ensure local storage directory exists
                Directory.CreateDirectory(_localStoragePath);
            }
        }

        private void InitializeContainer()
        {
            if (_blobServiceClient != null)
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                containerClient.CreateIfNotExists();
            }
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            if (_storageType.Equals("Azure", StringComparison.OrdinalIgnoreCase))
            {
                return await UploadToAzureAsync(fileStream, fileName, contentType);
            }
            else
            {
                return await UploadToLocalAsync(fileStream, fileName, contentType);
            }
        }

        private async Task<string> UploadToAzureAsync(Stream fileStream, string fileName, string contentType)
        {
            if (_blobServiceClient == null) throw new InvalidOperationException("Azure storage not configured");
            
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

            return blobClient.Uri.ToString();
        }

        private async Task<string> UploadToLocalAsync(Stream fileStream, string fileName, string contentType)
        {
            var filePath = Path.Combine(_localStoragePath, fileName);
            using (var fileStream2 = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fileStream2);
            }

            return $"/uploads/{fileName}";
        }

        public async Task DeleteFileAsync(string fileUrl)
        {
            if (_storageType.Equals("Azure", StringComparison.OrdinalIgnoreCase))
            {
                await DeleteFromAzureAsync(fileUrl);
            }
            else
            {
                await DeleteFromLocalAsync(fileUrl);
            }
        }

        private async Task DeleteFromAzureAsync(string fileUrl)
        {
            if (_blobServiceClient == null) throw new InvalidOperationException("Azure storage not configured");
            
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobName = Path.GetFileName(fileUrl);
            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }

        private async Task DeleteFromLocalAsync(string fileUrl)
        {
            var fileName = Path.GetFileName(fileUrl);
            var filePath = Path.Combine(_localStoragePath, fileName);
            
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public async Task<Stream> DownloadFileAsync(string fileUrl)
        {
            if (_storageType.Equals("Azure", StringComparison.OrdinalIgnoreCase))
            {
                return await DownloadFromAzureAsync(fileUrl);
            }
            else
            {
                return await DownloadFromLocalAsync(fileUrl);
            }
        }

        private async Task<Stream> DownloadFromAzureAsync(string fileUrl)
        {
            if (_blobServiceClient == null) throw new InvalidOperationException("Azure storage not configured");
            
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobName = Path.GetFileName(fileUrl);
            var blobClient = containerClient.GetBlobClient(blobName);

            var response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }

        private async Task<Stream> DownloadFromLocalAsync(string fileUrl)
        {
            var fileName = Path.GetFileName(fileUrl);
            var filePath = Path.Combine(_localStoragePath, fileName);
            
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }
    }
} 