using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Models.Enums;
using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<Role> _roleManager;

        public UserController(ILogger<WeatherForecastController> logger, 
                SignInManager<User> signIn, UserManager<User> manager,
                JWTService jwtService, RoleManager<Role> roleManager)
        {
            _logger = logger;
            _signIn = signIn;
            _manager = manager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody]LoginDTO loginDTO)
        {
            var user = await _manager.FindByEmailAsync(loginDTO.Email);
            if(user==null) return Unauthorized("Invalid email!!!");
            var result = await _signIn.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if(!result.Succeeded) return Unauthorized("Invalid email or password!!!");
            var roleList = await _manager.GetRolesAsync(user);
            var role = roleList.FirstOrDefault() ?? "Customer";
            var userInfo = new UserDTO();
            userInfo.Email = user.Email!;
            userInfo.Name = user.UserName!;
            userInfo.Token = _jwtService.CreateJwt(user, role);
            return userInfo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if(await _manager.FindByEmailAsync(registerDTO.Email) != null){
                return BadRequest("Email already exists!!!");
            }
            var user = new User{
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
                EmailConfirmed = true,
            };
            var result = await _manager.CreateAsync(user, registerDTO.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            bool roleExists = await _roleManager.RoleExistsAsync("Customer");
            if(!roleExists) await _roleManager.CreateAsync(new Role("Customer"));
            await _manager.AddToRoleAsync(user, "Customer");
            var userDTO = new UserDTO{
                Name = user.UserName,
                Email = user.Email,
                Token = _jwtService.CreateJwt(user, "Customer")
            };
            return Ok(userDTO);
        }

        [HttpPost("RegisterWithRole")]
        public async Task<ActionResult<User>> RegisterWithRole(RegisterDTO registerDTO, RoleEnum roleEnum)
        {
            if(await _manager.FindByEmailAsync(registerDTO.Email) != null){
                return BadRequest("Email already exists!!!");
            }
            var user = new User{
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
                EmailConfirmed = true,
            };
            var result = await _manager.CreateAsync(user, registerDTO.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            bool roleExists = await _roleManager.RoleExistsAsync(roleEnum.ToString());
            if(!roleExists) await _roleManager.CreateAsync(new Role(roleEnum.ToString()));
            await _manager.AddToRoleAsync(user, roleEnum.ToString());
            return Ok("Created successfully!!!");
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Customer, Admin, Host")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var list = _manager.Users;
            return Ok(list.ToList());
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRole()
        {
            var list = _roleManager.Roles;
            return Ok(list.ToList());
        }

        [HttpPost("AddRoles")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult> GetAllRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new Role(roleName));
            if(!result.Succeeded) return BadRequest("Bad request!!!");
            return Ok("Created!!!");
        }

        private string CreateUserToken(User user)
        {
            return _jwtService.CreateJwt(user, "Customer");
        }
    }
}
