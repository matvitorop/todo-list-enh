using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Goal;
using todo_list_enh.Server.Models.DTO.Task;
using todo_list_enh.Server.Repositories.Implementations;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Services.Implementations
{
    public class ActivityService<TActivity, TTask, TGoal> : IActivityService<TActivity, TTask, TGoal>
    where TActivity : class
    where TTask : class
    where TGoal : class
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goals;
        private readonly ITaskRepository _tasks;
        private readonly IActivityRepository<TActivity, TTask, TGoal> _activityRepository;

        public ActivityService(
            IMapper mapper,
            ITaskRepository taskRepository,
            IGoalRepository goalRepository,
            IActivityRepository<TActivity, TTask, TGoal> activityRepository)
        {
            _mapper = mapper;
            _tasks = taskRepository;
            _goals = goalRepository;
            _activityRepository = activityRepository;
        }

        public async Task<bool> AddActivity(AddActivityDTO dto)
        {
            var activity = _mapper.Map<TActivity>(dto);

            // Checking new date for uniqueness
            var startDateProperty = typeof(TActivity).GetProperty("StartDate");
            if (startDateProperty == null)
                throw new InvalidOperationException("StartDate propety doesnt exist");

            var startDateValue = dto.StartDate.Date;
            int userId = dto.UserId;

            while (await _activityRepository.AnyAsync(a =>
                EF.Property<int>(a, "UserId") == userId &&
                EF.Property<DateTime>(a, "StartDate") == startDateValue))
            {
                startDateValue = startDateValue.AddDays(typeof(TActivity) == typeof(Week) ? 7 : 1);
            }

            startDateProperty.SetValue(activity, startDateValue);

            await _activityRepository.AddAsync(activity);
            //await _activityRepository.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddActivityTask(AddTaskDTO taskDto, int activityId, int order)
        {
            var maxOrder = (await _activityRepository.GetAllTasks(activityId))
                .Max(t => (int?)EF.Property<int>(t, "Order")) ?? 0;

            order = maxOrder + 1;

            var existingActivityTask = (await _activityRepository.GetAllTasks(activityId))
                .FirstOrDefault(t => EF.Property<int>(t, "Order") == order);

            if (existingActivityTask != null)
            {
                return false;
            }

            var baseTask = _mapper.Map<Models.Domain.Task>(taskDto);
            await _tasks.AddAsync(baseTask);

            var newTask = _mapper.Map<TTask>(baseTask);

            typeof(TTask).GetProperty("periodId")?.SetValue(newTask, activityId);
            typeof(TTask).GetProperty("Order")?.SetValue(newTask, order);

            await _activityRepository.AddTask(newTask);
            return true;
        }

        public async Task<bool> AddActivityGoal(AddGoalDTO goalDto, int activityId)
        {
            var baseGoal = _mapper.Map<Goal>(goalDto);
            await _goals.AddAsync(baseGoal);

            var newGoal = _mapper.Map<TGoal>(baseGoal);

            typeof(TGoal).GetProperty("periodId")?.SetValue(newGoal, activityId);
            typeof(TGoal).GetProperty("GoalId")?.SetValue(newGoal, baseGoal.Id);
            
            await _activityRepository.AddGoal(newGoal);

            return true;
        }

        public async Task<IEnumerable<TTask>> GetUserTasks(int activityId)
        {
            var tasks = await GetTasksFromRepository(activityId);
            return tasks;
        }

        public async Task<IEnumerable<TGoal>> GetUserGoals(int activityId)
        {
            var goals = await GetGoalsFromRepository(activityId);
            return goals;
        }

        private async Task<IEnumerable<TTask>> GetTasksFromRepository(int activityId)
        {
            var tasks = await _activityRepository.GetAllTasksWithDetails(activityId);
            return tasks;
        }

        private async Task<IEnumerable<TGoal>> GetGoalsFromRepository(int activityId)
        {
            var goals = await _activityRepository.GetAllGoalsWithDetails(activityId);
            return goals;
        }

        public async Task<IEnumerable<ActivityDTO>> GetUserPeriods(int userId)
        {
            var userPeriods = await _activityRepository.FindAsync(t => EF.Property<int>(t, "UserId") == userId);
            
            return _mapper.Map<List<ActivityDTO>>(userPeriods);
        }
    }
}