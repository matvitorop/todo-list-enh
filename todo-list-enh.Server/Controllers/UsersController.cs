using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.User;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services;
using todo_list_enh.Server.Services.Implementations;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly TokenGenerator _token;

        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, IMapper mapper, TokenGenerator token, IUserService userService)
        {
            this._logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this._token = token;
            this._userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO userDTO)
        {
            var result = await _userService.RegisterAsync(userDTO);

            if (result == null)
            {
                return BadRequest("User already exists.");
            }

            return Ok(new
            {
                Token = result.Value.Token,
                User = result.Value.User
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AddUserDTO userDTO)
        {
            var result = await _userService.LoginAsync(userDTO);

            if (result == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(new
            {
                Token = result.Value.Token,
                User = result.Value.User
            });
        }

        // TOKEN AUTHORIZE TEST
        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
