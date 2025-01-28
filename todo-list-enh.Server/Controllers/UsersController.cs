using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services;

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(ILogger<WeatherForecastController> logger, IUserRepository userRepository, IMapper mapper)
        {
            this._logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id) 
        {
            var user = await userRepository.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<UserDTO>(user);

            return Ok(userDTO);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO userDTO)
        {
            if (await userRepository.CheckUserByEmail(userDTO))
            {
                var userDomain = mapper.Map<User>(userDTO);
                
                return Ok(await userRepository.AddUser(userDomain));
            }

            return BadRequest("User already exists.");
        }
    }
}
