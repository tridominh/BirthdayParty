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

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetAllServices()
        {
            List<Service> services = bookingService.GetAllServices();

            if (services == null || services.Count == 0)
            {
                return NotFound();
            }

            return Ok(services);
        }
    }
}
