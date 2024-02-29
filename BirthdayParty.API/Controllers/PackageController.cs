using BirthdayParty.Models;
using BirthdayParty.Models.Converters;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;


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
        public async Task<ActionResult<List<Package>>> GetAllPackages()
        {
            List<Package> packages = packageService.GetAllPackages();

            if (packages == null || packages.Count == 0)
            {
                return NotFound();
            }

            return Ok(packages);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Package>> CreatePackage([FromBody] PackageCreateDto packageCreateDto)
        {
            Package package = PackageConverter.toEntity(packageCreateDto);

            packageService.CreatePackage(package);

            return Ok(new { Message = "Create Package Successfully", Data = packageCreateDto });
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Package>> UpdatePackage([FromBody] PackageUpdateDto packageUpdateDto)
        {
            Package updatedPackage = PackageConverter.toEntity(packageUpdateDto);

            Package package = packageService.UpdatePackage(packageUpdateDto.PackageId, updatedPackage);

            if(package == null)
            {
                return NotFound();   
            }

            return Ok(new { Message = "Update Package Successfully", Data =  package});
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Package>> DeletePackage([FromBody] int id)
        {
            Package package = packageService.DeletePackage(id);

            if(package == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Delete Package Successfully", Data = package });
        }
    }
}
