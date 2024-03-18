using BirthdayParty.Models;
using BirthdayParty.Models.Converters;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BirthdayParty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;

        public PackageController(IPackageService packageService) {
            this.packageService = packageService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Packages>>> GetAllPackages()
        {
            List<Packages> packages = packageService.GetAllPackages();

            //if (packages == null || packages.Count == 0)
            //{
            //    return NotFound();
            //}

            return Ok(packages);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Packages>> CreatePackage([FromBody] PackageCreateDto packageCreateDto)
        {
            Packages package = PackageConverter.toEntity(packageCreateDto);

            packageService.CreatePackage(package);

            return Ok(new { Message = "Create Packages Successfully", Data = packageCreateDto });
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Packages>> UpdatePackage([FromBody] PackageUpdateDto packageUpdateDto)
        {
            Packages updatedPackage = PackageConverter.toEntity(packageUpdateDto);

            Packages package = packageService.UpdatePackage(packageUpdateDto.PackageId, updatedPackage);

            if(package == null)
            {
                return NotFound();   
            }

            return Ok(new { Message = "Update Packages Successfully", Data =  package});
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Packages>> DeletePackage([FromBody] int id)
        {
            Packages package = packageService.DeletePackage(id);

            if(package == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Delete Packages Successfully", Data = package });
        }

        [HttpGet("GetAllServicesByPackageId")]
        public async Task<ActionResult<List<Service>>> GetAllServicesByPackageId(int id)
        {
            List<Service> services = packageService.GetAllServicesByPackageId(id);

            if(services == null || services.Count == 0)
            {
                return NotFound();
            }
            return Ok(services);
        }
    }
}
