using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace BirthdayParty.Services;

public class UploadFileService : IUploadFileService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _blobContainerClient;

    private static readonly long ONE_MEGABYTE = 1024 * 1024;
    private static readonly long FILE_SIZE_LIMIT = 10 * ONE_MEGABYTE; //10MB
    
    public UploadFileService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("swd");
        _blobContainerClient.CreateIfNotExists();
    }

    public async Task<string> UploadFileAsync(IFormFile file, bool uploadImage = false)
    {
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (file.Length > FILE_SIZE_LIMIT)
            {
                throw new Exception($"File size larger than {FILE_SIZE_LIMIT / ONE_MEGABYTE}MB");
            }

            string blobName = $"{Guid.NewGuid()}_{file.FileName}";
            BlobClient blobClient = _blobContainerClient.GetBlobClient(blobName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            if(uploadImage){
                await blobClient.SetHttpHeadersAsync(new BlobHttpHeaders { ContentType = "image/jpeg" });
            }

            return blobClient.Uri.ToString();
    }
    public async Task<bool> DeleteFileAsync(string blobName)
    {
        BlobClient blob = _blobContainerClient.GetBlobClient(blobName);
        try
        {
            var result = await blob.DeleteIfExistsAsync(snapshotsOption: DeleteSnapshotsOption.IncludeSnapshots);
            return result.Value;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            throw new Exception("File not found");
        }
        catch (RequestFailedException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<string>> GetAllFileAsync()
    {
        var fileList = _blobContainerClient.GetBlobs().ToList().Select(x => x.Name);
        return await Task.FromResult(fileList);
    }
}
