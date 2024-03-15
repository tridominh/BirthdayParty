using BirthdayParty.Models;
using BirthdayParty.Models.Converters;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;
using BirthdayParty.Services.PaymentService.Momo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace BirthdayParty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomoController : ControllerBase
    {
        private readonly MomoService _momoService;
        private readonly MomoConfig _config;

        public MomoController(MomoService momoService, IOptions<MomoConfig> config){
            _momoService = momoService;
            _config = config.Value;
        }

        [HttpPost("CreateMomoLink")]
        public async Task<ActionResult<string>> CreateMomoLink()
        {
            MomoOneTimePaymentRequest request = _momoService.CreateRequestModel(500000);
            var result = request.GetLink(_config.PaymentUrl);
            return result.Item2;
        }

        [HttpPost("momo-ipn")]
        public async Task<ActionResult> MomoNotification()
        {
            Console.WriteLine("Hello");
            return Ok();
        }
    }
}
