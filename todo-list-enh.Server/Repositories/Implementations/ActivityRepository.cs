using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class ActivityRepository<TActivity, TTask, TGoal> : Repository<TActivity>, IActivityRepository<TActivity, TTask, TGoal>
        where TActivity : class
        where TTask : class
        where TGoal : class
    {
        private readonly ETLDbContext _context;
        private readonly DbSet<TTask> _tasks;
        private readonly DbSet<TGoal> _goals;
        private readonly Repository<TTask> _taskRepository;
        private readonly Repository<TGoal> _goalRepository;

        public ActivityRepository(ETLDbContext context) : base(context)
        {
            _context = context;
            _tasks = context.Set<TTask>();
            _goals = context.Set<TGoal>();

            _taskRepository = new Repository<TTask>(_context);
            _goalRepository = new Repository<TGoal>(_context);
        }

        public async Task<IEnumerable<TTask>> GetAllTasks(int activityId)
        {
            return await _taskRepository.FindAsync(t => EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId);


           //return await _tasks.Where(t => EF.Property<int>(t, "WeekId") == activityId ||
           //                               EF.Property<int>(t, "DayId") == activityId)
           //                   .ToListAsync();
        }

        public async Task<IEnumerable<TGoal>> GetAllGoals(int activityId)
        {
            return await _goalRepository.FindAsync(t => EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId);

            //return await _goals.Where(g => EF.Property<int>(g, "WeekId") == activityId ||
            //                               EF.Property<int>(g, "DayId") == activityId)
            //                   .ToListAsync();
        }

        public async Task<IEnumerable<TTask>> GetNotOverdueTasks(int activityId, DateTime currentTime)
        {
            return await _taskRepository.FindAsync(t =>
                (EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId) &&
                EF.Property<bool>(t, "IsCompleted") == false &&
                (EF.Property<TimeSpan?>(t, "EndTime") == null || EF.Property<TimeSpan>(t, "EndTime") > currentTime.TimeOfDay));

            //return await _tasks.Where(t =>
            //    (EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId) &&
            //    EF.Property<bool>(t, "IsCompleted") == false &&
            //    (EF.Property<TimeSpan?>(t, "EndTime") == null || EF.Property<TimeSpan>(t, "EndTime") > currentTime.TimeOfDay)
            //).ToListAsync();
        }

        public async Task<bool> DeleteTask(int activityId, int taskId)
        {
            return await DeleteItem<TTask>(activityId, taskId);
        }

        public async Task<bool> DeleteGoal(int activityId, int goalId)
        {
            return await DeleteItem<TGoal>(activityId, goalId);
        }

        public async Task<bool> DeleteItem<T>(int activityId, int itemId) where T : class
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e =>
                (EF.Property<int>(e, "WeekId") == activityId || EF.Property<int>(e, "DayId") == activityId) &&
                 EF.Property<int>(e, "TaskId") == itemId || EF.Property<int>(e, "GoalId") == itemId);

            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeTaskOrder(int activityId, int taskIdToReplace, int taskIdToRemove)
        {
            var taskToReplace = await _tasks.FirstOrDefaultAsync(t =>
                (EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId) &&
                EF.Property<int>(t, "TaskId") == taskIdToReplace);

            var taskToRemove = await _tasks.FirstOrDefaultAsync(t =>
                (EF.Property<int>(t, "WeekId") == activityId || EF.Property<int>(t, "DayId") == activityId) &&
                EF.Property<int>(t, "TaskId") == taskIdToRemove);

            if (taskToReplace == null || taskToRemove == null)
                return false;

            var tempOrder = EF.Property<int>(taskToReplace, "Order");
            _context.Entry(taskToReplace).Property("Order").CurrentValue = EF.Property<int>(taskToRemove, "Order");
            _context.Entry(taskToRemove).Property("Order").CurrentValue = tempOrder;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTask(int activityId, int taskId)
        {
            var newTask = (TTask)Activator.CreateInstance(typeof(TTask))!;
            _context.Entry(newTask).Property("TaskId").CurrentValue = taskId;

            if (typeof(TTask).GetProperty("WeekId") != null)
                _context.Entry(newTask).Property("WeekId").CurrentValue = activityId;
            else
                _context.Entry(newTask).Property("DayId").CurrentValue = activityId;

            await _tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddGoal(int activityId, int goalId)
        {
            var newGoal = (TGoal)Activator.CreateInstance(typeof(TGoal))!;
            _context.Entry(newGoal).Property("GoalId").CurrentValue = goalId;

            if (typeof(TGoal).GetProperty("WeekId") != null)
                _context.Entry(newGoal).Property("WeekId").CurrentValue = activityId;
            else
                _context.Entry(newGoal).Property("DayId").CurrentValue = activityId;

            await _goals.AddAsync(newGoal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
