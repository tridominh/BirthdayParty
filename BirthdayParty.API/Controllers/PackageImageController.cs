using BirthdayParty.Models.DTOs;
using BirthdayParty.Models.LocalImages;
using BirthdayParty.Repository;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageImageController : ControllerBase
    {
        private readonly IPackageImageLocalService _packageImageService;

        public PackageImageController(IPackageImageLocalService packageImageService)
        {
            _packageImageService= packageImageService;
        }

        [HttpGet("GetAllPackageImages")]
        public async Task<ActionResult<List<PackageImageLocal>>> GetAllPackageImages()
        {
            var packages = _packageImageService.GetAllPackageImages();

            if (packages == null || packages.Count() == 0)
            {
                return NotFound();
            }

            return Ok(packages);
        }
        [HttpPut("UpdatePackageImages")]
        public async Task<ActionResult<PackageImageLocal>> UpdatePackageImage([FromForm]PackageImageDto packageImage)
        {
            var existingPackage = _packageImageService.GetPackageImage(packageImage.PackageImageId);

            if (existingPackage == null)
            {
                return NotFound();
            }

            try
            {
                var result = _packageImageService.UpdatePackageImage(existingPackage);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
        }

        [HttpDelete("DeletePackageImage")]
        public async Task<ActionResult> DeletePackageImage(int id)
        {
            var result = _packageImageService.DeletePackageImage(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("CreatePackageImage")]
        public async Task<ActionResult<PackageImageLocal>> CreatePackageImage([FromForm]PackageImageDto packageImage)
        {
            byte[] file = FileConvertUtils.ConvertToByteArray(packageImage.Image);
            var packageImageObj = new PackageImageLocal{
                PackageId = packageImage.PackageId,
                Image = file,
            };
            _packageImageService.CreatePackageImage(packageImageObj);
            return Ok();
        }
    }
}
