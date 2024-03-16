using BirthdayParty.Models.DTOs;
using BirthdayParty.Models.LocalImages;
using BirthdayParty.Repository;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceImageController : ControllerBase
    {
        private readonly IServiceImageLocalService _serviceImageService;

        public ServiceImageController(IServiceImageLocalService serviceImageService)
        {
            _serviceImageService = serviceImageService;
        }

        [HttpGet("GetAllServiceImages")]
        public async Task<ActionResult<List<ServiceImageLocal>>> GetAllServiceImages()
        {
            var services = _serviceImageService.GetAllServiceImages();

            if (services == null || services.Count() == 0)
            {
                return NotFound();
            }

            return Ok(services);
        }
        [HttpPut("UpdateServiceImages")]
        public async Task<ActionResult<ServiceImageLocal>> UpdateServiceImage([FromForm]ServiceImageDto serviceImage)
        {
            var existingService = _serviceImageService.GetServiceImage(serviceImage.ServiceImageId);

            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                var result = _serviceImageService.UpdateServiceImage(existingService);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
        }

        [HttpDelete("DeleteServiceImage")]
        public async Task<ActionResult> DeleteServiceImage(int id)
        {
            var result = _serviceImageService.DeleteServiceImage(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("CreateServiceImage")]
        public async Task<ActionResult<ServiceImageLocal>> CreateRoomImage([FromForm]ServiceImageDto serviceImage)
        {
            byte[] file = FileConvertUtils.ConvertToByteArray(serviceImage.Image);
            var serviceImageObj = new ServiceImageLocal{
                ServiceId = serviceImage.ServiceId,
                Image = file,
            };
            _serviceImageService.CreateServiceImage(serviceImageObj);
            return Ok();
        }
    }
}
