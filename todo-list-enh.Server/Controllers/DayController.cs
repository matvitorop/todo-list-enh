using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list_enh.Server.Extensions;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Goal;
using todo_list_enh.Server.Models.DTO.Task;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly ILogger<DayController> _logger;

        private readonly IActivityRepository<Day, DailyTask, DailyGoal> _dayActivityRepository;
        private readonly IActivityService<Day, DailyTask, DailyGoal> _dayActivityService;

        public DayController(
            ILogger<DayController> logger,

            IActivityRepository<Day, DailyTask, DailyGoal> dayActivityRepository,

            ITaskRepository taskRepository,
            IGoalRepository goalRepository,

            IActivityService<Day, DailyTask, DailyGoal> dayActivityService
        )
        {
            this._logger = logger;

            this._dayActivityRepository = dayActivityRepository;

            this._dayActivityService = dayActivityService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDay()
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            AddActivityDTO activity = new AddActivityDTO();
            activity.UserId = userId;


            if (!await _dayActivityService.AddActivity(activity))
            {
                return BadRequest("User already exists.");
            }

            return Ok("Activity created successfully");
        }

        [Authorize]
        [HttpPost]
        [Route("addTask")]
        public async Task<IActionResult> AddTask([FromBody] AddActivityTaskDTO data)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var result = await _dayActivityService.AddActivityTask(data.AddTask, data.ActivityId, data.order);


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

            var result = await _dayActivityService.AddActivityGoal(data.AddGoal, data.ActivityId);

            if (result)
            {
                return Ok("Goal created successfully.");
            }

            return BadRequest("Data error.");
        }

        [Authorize]
        [HttpPost]
        [Route("getTasks")]
        public async Task<IActionResult> GetTasks([FromBody] int activityID)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var result = await _dayActivityService.GetUserTasks(activityID);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Data error.");
        }

        [Authorize]
        [HttpPost]
        [Route("getGoals")]
        public async Task<IActionResult> GetGoals([FromBody] int activityID)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var result = await _dayActivityService.GetUserGoals(activityID);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Data error.");
        }

        [Authorize]
        [HttpPost]
        [Route("getPeriods")]
        public async Task<IActionResult> getPeriods()
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var result = await _dayActivityService.GetUserPeriods(userId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Data error.");
        }
    }
}