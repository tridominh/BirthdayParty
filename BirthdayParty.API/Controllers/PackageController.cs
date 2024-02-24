using BirthdayParty.Models;
using BirthdayParty.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;

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

        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetAllPackages()
        {
            List<Package> packages = packageService.GetAllPackages();

            if(packages == null || packages.Count == 0)
            {
                return NotFound();
            }

            return Ok(packages);        
        }
    }
}
