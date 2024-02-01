using Microsoft.AspNetCore.Http;

namespace BirthdayParty.Services;
public interface IUploadFileService
{
    //Task<BlobInfo> GetBlobAsync(string name);
   //Task<IEnumerable<string>> ListBlobAsync();
    Task<string> UploadFileAsync(IFormFile file, bool uploadImage = false);
    Task<bool> DeleteFileAsync(string blobName);
    Task<IEnumerable<string>> GetAllFileAsync();
    //Task UploadContentBlobAsync(string content, string fileName);
    //Task DeleteBlobAsync(string blobName);
}
