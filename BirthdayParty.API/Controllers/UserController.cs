using BirthdayParty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SignInManager<User> _signIn;
        private readonly JWTService _jwtService;
        private readonly UserManager<User> _manager;

        public UserController(ILogger<WeatherForecastController> logger, 
                SignInManager<User> signIn, UserManager<User> manager,
                JWTService jwtService)
        {
            _logger = logger;
            _signIn = signIn;
            _manager = manager;
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            var user = await _manager.FindByEmailAsync(email);
            if(user==null) return Unauthorized("Invalid email!!!");
            var result = await _signIn.CheckPasswordSignInAsync(user, password, false);
            if(!result.Succeeded) return Unauthorized("Invalid email or password!!!");
            return CreateUserToken(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(string email, string password, string name)
        {
            if(await _manager.FindByEmailAsync(email) != null){
                return BadRequest("Email already exists!!!");
            }
            var user = new User{
                UserName = name,
                Email = email,
                EmailConfirmed = true,
            };
            var result = await _manager.CreateAsync(user, password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            return Ok("Created successfully!!!");
        }

        private User CreateUserToken(User user)
        {
            user.Jwt = _jwtService.CreateJwt(user);
            return user;
        }
    }
}
