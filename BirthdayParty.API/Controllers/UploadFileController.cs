using BirthdayParty.Models.DTOs;
using BirthdayParty.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileService _uploadFileService;

        public UploadFileController(IUploadFileService uploadService)
        {
            _uploadFileService = uploadService;
        }

        [HttpGet("GetAllFiles")]
        [Authorize]
        public async Task<ActionResult> GetAllFiles()
        {
            var fileList = await _uploadFileService.GetAllFileAsync();
            return Ok(fileList);
        }

        [HttpPost("UploadFiles")]
        [Authorize]
        public async Task<ActionResult> UploadFiles([FromForm]UploadFileDTO file)
        {
            string uploadedLink = "";
            if(file.IsUploadingImage)
                uploadedLink = await _uploadFileService.UploadFileAsync(file.File, true);
            else
                uploadedLink = await _uploadFileService.UploadFileAsync(file.File);
            return Ok(uploadedLink);
        }

        [HttpDelete("DeleteFile")]
        [Authorize]
        public async Task<ActionResult> DeleteFile(string fileName)
        {
            bool result = await _uploadFileService.DeleteFileAsync(fileName);
            if(result) return Ok($"File {fileName} has been deleted");
            else return BadRequest("Error has occured!!!");
        }
    }
}
