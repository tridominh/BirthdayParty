using BirthdayParty.Models;
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
