using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Task;
using todo_list_enh.Server.Repositories.Implementations;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Services.Implementations
{
    public class ActivityService<TActivity, TTask> : IActivityService<TActivity, TTask>
    where TActivity : class
    where TTask : class
    {
        private readonly ETLDbContext _context;
        private readonly IMapper _mapper;
        private readonly Repository<Models.Domain.Task> _tasks;
        private readonly Repository<Goal> _goals;

        public ActivityService(ETLDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddActivity(AddActivityDTO dto)
        {
            var activity = _mapper.Map<TActivity>(dto);

            await _context.Set<TActivity>().AddAsync(activity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActivityTask(int activityId, AddTaskDTO task, int order)
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
            await _context.SaveChangesAsync();

            var newActivityTask = Activator.CreateInstance<TTask>();
            typeof(TTask).GetProperty("periodId")?.SetValue(newActivityTask, activityId);
            typeof(TTask).GetProperty("taskId")?.SetValue(newActivityTask, newTask.Id);
            typeof(TTask).GetProperty("order")?.SetValue(newActivityTask, order);

            await _context.Set<TTask>().AddAsync(newActivityTask);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
