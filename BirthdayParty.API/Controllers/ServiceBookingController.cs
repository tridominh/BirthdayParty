using BirthdayParty.Models;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceBookingController : ControllerBase
    {
        private readonly IServiceBookingService bookingService;

        public ServiceBookingController(IServiceBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("GetAllServices")]
        public async Task<ActionResult<List<Service>>> GetAllServices()
        {
            List<Service> services = bookingService.GetAllServices();

            if (services == null || services.Count == 0)
            {
                return NotFound();
            }

            return Ok(services);
        }
        [HttpPost("UpdateService")]
        public async Task<ActionResult<Service>> UpdateService(Service updatedService)
        {
            var existingService = bookingService.GetServiceById(updatedService.ServiceId);

            if (existingService == null)
            {
                return NotFound();
            }

            try
            {
                var result = bookingService.UpdateService(updatedService);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
        }

        [HttpDelete("DeleteService")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var result = bookingService.DeleteService(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("CreateService")]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {
            bookingService.CreateService(service);
            return Ok();
        }
    }
}
