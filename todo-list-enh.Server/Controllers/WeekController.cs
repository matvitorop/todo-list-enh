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
using todo_list_enh.Server.Models.DTO.Goal;

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IActivityRepository<Week, WeekTask, WeekGoal> _weekActivityRepository;
        private readonly IActivityService<Week, WeekTask, WeekGoal> _weekActivityService;

        private readonly IActivityRepository<Day, DailyTask, WeekGoal> _dayActivityRepository;
        private readonly IActivityService<Day, DailyTask, DailyGoal> _dayActivityService;

        public WeekController(
            ILogger<UsersController> logger,
            
            IActivityRepository<Week, WeekTask, WeekGoal> weekActivityRepository,
            //IActivityRepository<Day, DailyTask, WeekGoal> dayActivityRepository,
            
            ITaskRepository taskRepository,
            IGoalRepository goalRepository,

            IActivityService<Week, WeekTask, WeekGoal> weekActivityService
            //IActivityService<Day, DailyTask> dayActivityService
        )
        {
            this._logger = logger;

            this._weekActivityRepository = weekActivityRepository;
            //this._dayActivityRepository = dayActivityRepository;

            this._weekActivityService = weekActivityService;
            //this._dayActivityService = dayActivityService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWeek()
        {
            var userId = this.GetUserIdOrThrowUnauthorized();
            
            AddActivityDTO activity = new AddActivityDTO();
            activity.UserId = userId;


            if (!await _weekActivityService.AddActivity(activity))
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
            
            var result = await _weekActivityService.AddActivityTask(data.AddTask, data.ActivityId, data.order);
            
            
            if (result)
            {
                return Ok("Task created successfully.");
            }
            
            return BadRequest("Data error.");
        }

        [Authorize]
        [HttpPost]
        [Route("addGoal")]
        public async Task<IActionResult> AddGoal([FromBody] AddActivityGoalDTO data)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var result = await _weekActivityService.AddActivityGoal(data.AddGoal, data.ActivityId/*, data.order*/);

            if (result)
            {
                return Ok("Goal created successfully.");
            }

            return BadRequest("Data error.");
        }
    }
}
