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

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, IMapper mapper, TokenGenerator token)
        {
            this._logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this._token = token;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id) 
        {
            var user = await userRepository.GetByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<UserDTO>(user);

            return Ok(userDTO);
        }

        // ADD USER SERVICE 
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO userDTO)
        {
            if (await userRepository.CheckUserByEmail(userDTO))
            {
                return BadRequest("User already exists.");
            }

            var userDomain = mapper.Map<User>(userDTO);
            var createdUser = await userRepository.AddUser(userDomain);

            var token = _token.GenerateJwtToken(createdUser);

            return Ok(new
            {
                Token = token,
                Username = createdUser.Username
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AddUserDTO userDTO)
        {
            var userDomain = await userRepository.GetByEmailAndPassword(userDTO.Email, userDTO.Password);

            if (userDomain != null)
            {
                var token = _token.GenerateJwtToken(userDomain);

                return Ok(new { user = userDomain, Token = token });
            }

            return BadRequest("Invalid email or password");
        }

        // TOKEN AUTHORIZE TEST
        [Authorize]
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var user = await userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }
    }
}
