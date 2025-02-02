using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;
using todo_list_enh.Server.Services;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Services.Implementations;
using todo_list_enh.Server.Models.DTO.User;
using todo_list_enh.Server.Models.DTO.Activity;
using Microsoft.AspNetCore.Authorization;
using todo_list_enh.Server.Extensions;
using todo_list_enh.Server.Models.DTO.Task;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Repositories.Implementations;

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IActivityRepository<Week, WeekTask, WeekGoal> _activityRepository;
        private readonly IActivityService<Week, WeekTask> _activityService;
        
        private readonly IMapper mapper;
        private readonly ETLDbContext _context;
        private readonly ITaskRepository _tasks;

        public WeekController(
            ILogger<UsersController> logger,
            IActivityRepository<Week, WeekTask, WeekGoal> activityRepository,
            IMapper mapper,
            IActivityService<Week, WeekTask> activityService,
            ETLDbContext context,
            ITaskRepository taskRepository
        )
        {
            this._logger = logger;
            this._activityRepository = activityRepository;
            this.mapper = mapper;
            this._activityService = activityService;
            this._context = context;
            this._tasks = taskRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWeek()
        {
            var userId = this.GetUserIdOrThrowUnauthorized();
            
            AddActivityDTO activity = new AddActivityDTO();
            activity.UserId = userId;


            if (!await _activityService.AddActivity(activity))
            {
                return BadRequest("User already exists.");
            }

            return Ok("activity created successfully");
        }

        [Authorize]
        [HttpPost]
        [Route("addTask")]
        public async Task<IActionResult> AddTask([FromBody] AddActivityTaskDTO data)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();
            
            var result = await _activityService.AddActivityTask(data.ActivityId, data.AddTask, data.order);
            
            
            if (result)
            {
                return Ok("Activity created successfully.");
            }
            
            return BadRequest("Data error.");
        }
    }
}
