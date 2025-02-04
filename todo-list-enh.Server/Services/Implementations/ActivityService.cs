﻿using AutoMapper;
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
        private readonly ETLDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goals;
        private readonly ITaskRepository _tasks;

        private readonly IActivityRepository<Day, DailyTask, DailyGoal> _dayActivityRepository;
        private readonly IActivityRepository<Week, WeekTask, WeekGoal> _weekActivityRepository;

        public ActivityService(ETLDbContext context, 
            IMapper mapper, 
            ITaskRepository taskRepository, 
            IGoalRepository goalRepository, 
            IActivityRepository<Day, DailyTask, DailyGoal> dayActivityRepository, 
            IActivityRepository<Week, WeekTask, WeekGoal> weekActivityRepository)
        {
            _context = context;
            _mapper = mapper;
            this._tasks = taskRepository;
            this._goals = goalRepository;

            this._dayActivityRepository = dayActivityRepository;
            this._weekActivityRepository = weekActivityRepository;
        }

        public async Task<bool> AddActivity(AddActivityDTO dto)
        {
            var activity = _mapper.Map<TActivity>(dto);

            await _context.Set<TActivity>().AddAsync(activity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActivityTask(AddTaskDTO task, int activityId, int order)
        {
            var maxOrder = await _context.Set<TTask>()
                .Where(t => EF.Property<int>(t, "periodId") == activityId)
                .MaxAsync(t => (int?)EF.Property<int>(t, "Order")) ?? 0;

            order = maxOrder + 1;

            var existingActivityTask = await _context.Set<TTask>().FirstOrDefaultAsync(t =>
                EF.Property<int>(t, "periodId") == activityId &&
                EF.Property<int>(t, "Order") == order);

            if (existingActivityTask != null)
            {
                return false;
            }

            var newTask = _mapper.Map<Models.Domain.Task>(task);
            await _tasks.AddAsync(newTask);

            var newActivityTask = Activator.CreateInstance<TTask>();
            // names of model's props
            typeof(TTask).GetProperty("periodId")?.SetValue(newActivityTask, activityId);
            typeof(TTask).GetProperty("TaskId")?.SetValue(newActivityTask, newTask.Id);
            typeof(TTask).GetProperty("Order")?.SetValue(newActivityTask, order);

            await _context.Set<TTask>().AddAsync(newActivityTask);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActivityGoal(AddGoalDTO goal, int activityId)
        {

            //var existingActivityGoal = await _context.Set<TGoal>().FirstOrDefaultAsync(g =>
            //    EF.Property<int>(g, "periodId") == activityId);
            //
            //if (existingActivityGoal != null)
            //{
            //    return false;
            //}

            var newGoal = _mapper.Map<Goal>(goal);
            await _goals.AddAsync(newGoal);

            var newActivityGoal = Activator.CreateInstance<TGoal>();
            typeof(TGoal).GetProperty("periodId")?.SetValue(newActivityGoal, activityId);
            typeof(TGoal).GetProperty("GoalId")?.SetValue(newActivityGoal, newGoal.Id);

            await _context.Set<TGoal>().AddAsync(newActivityGoal);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TTask>> GetUserTasks(int userId)
        {
            var tasks = await GetTasksFromRepository(userId);
            return tasks;
        }

        public async Task<IEnumerable<TGoal>> GetUserGoals(int userId)
        {
            var goals = await GetGoalsFromRepository(userId);
            return goals;
        }

        private async Task<IEnumerable<TTask>> GetTasksFromRepository(int activityId)
        {
            object? repository = typeof(TActivity) == typeof(Day) ? _dayActivityRepository
                             : typeof(TActivity) == typeof(Week) ? _weekActivityRepository
                             : throw new InvalidOperationException($"Unsupported activity type: {typeof(TActivity).Name}");

            var tasks = await ((IActivityRepository<TActivity, TTask, TGoal>)repository).GetAllTasks(activityId);
            return tasks;
        }

        private async Task<IEnumerable<TGoal>> GetGoalsFromRepository(int activityId)
        {
            object? repository = typeof(TActivity) == typeof(Day) ? _dayActivityRepository
                             : typeof(TActivity) == typeof(Week) ? _weekActivityRepository
                             : throw new InvalidOperationException($"Unsupported activity type: {typeof(TActivity).Name}");

            var goals = await ((IActivityRepository<TActivity, TTask, TGoal>)repository).GetAllGoals(activityId);
            return goals;
        }

    }
}
