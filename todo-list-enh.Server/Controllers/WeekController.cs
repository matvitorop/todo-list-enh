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

namespace todo_list_enh.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IActivityRepository<Week, WeekTask, WeekGoal> _activityRepository;
        private readonly IMapper mapper;
        private readonly IActivityService<Week, WeekTask> _activityService;

        public WeekController(ILogger<UsersController> logger, IActivityRepository<Week, WeekTask, WeekGoal> activityRepository, IMapper mapper, IActivityService<Week, WeekTask> activityService)
        {
            this._logger = logger;
            this._activityRepository = activityRepository;
            this.mapper = mapper;
            this._activityService = activityService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register()
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
    }
}
