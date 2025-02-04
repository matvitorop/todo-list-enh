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
        private readonly Repository<TTask> _taskRepository;
        private readonly Repository<TGoal> _goalRepository;
        public ActivityRepository(ETLDbContext context) : base(context)
        {
            _context = context;
            _taskRepository = new Repository<TTask>(_context);
            _goalRepository = new Repository<TGoal>(_context);
        }

        public async Task<IEnumerable<TTask>> GetAllTasks(int activityId)
        {
            return await _taskRepository.FindAsync(t => EF.Property<int>(t, "periodId") == activityId);
        }

        public async Task<IEnumerable<TGoal>> GetAllGoals(int activityId)
        {
            return await _goalRepository.FindAsync(g => EF.Property<int>(g, "periodId") == activityId);
        }

        public async Task<IEnumerable<TTask>> GetNotOverdueTasks(int activityId, DateTime currentTime)
        {
            return await _taskRepository.FindAsync(t =>
                EF.Property<int>(t, "periodId") == activityId &&
                !EF.Property<bool>(t, "IsCompleted") &&
                (EF.Property<TimeSpan?>(t, "EndTime") == null || EF.Property<TimeSpan>(t, "EndTime") > currentTime.TimeOfDay));
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
                EF.Property<int>(e, "periodId") == activityId &&
                (EF.Property<int?>(e, "TaskId") == itemId || EF.Property<int?>(e, "GoalId") == itemId));

            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeTaskOrder(int activityId, int taskIdToReplace, int taskIdToRemove)
        {
            var taskToReplace = await _taskRepository.FindOneAsync(t =>
                EF.Property<int>(t, "periodId") == activityId &&
                EF.Property<int>(t, "TaskId") == taskIdToReplace);

            var taskToRemove = await _taskRepository.FindOneAsync(t =>
                EF.Property<int>(t, "periodId") == activityId &&
                EF.Property<int>(t, "TaskId") == taskIdToRemove);

            if (taskToReplace == null || taskToRemove == null)
                return false;

            var tempOrder = EF.Property<int>(taskToReplace, "Order");
            _context.Entry(taskToReplace).Property("Order").CurrentValue = EF.Property<int>(taskToRemove, "Order");
            _context.Entry(taskToRemove).Property("Order").CurrentValue = tempOrder;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddTask(TTask task)
        {
            await _taskRepository.AddAsync(task);
            return true;
        }

        public async Task<bool> AddGoal(TGoal goal)
        {
            await _goalRepository.AddAsync(goal);
            return true;
        }
    }
}