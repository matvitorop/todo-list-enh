namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IActivityRepository<TActivity, TTask, TGoal> : IRepository<TActivity> where TActivity : class
    {
        Task<IEnumerable<TTask>> GetAllTasks(int activityId);
        Task<IEnumerable<TGoal>> GetAllGoals(int activityId);
        Task<IEnumerable<TTask>> GetNotOverdueTasks(int activityId, DateTime currentTime);
        Task<bool> DeleteItem<T>(int activityId, int itemId) where T : class;
        Task<bool> ChangeTaskOrder(int activityId, int taskIdToReplace, int taskIdToRemove);
        Task<bool> AddTask(int activityId, int taskId);
        Task<bool> AddGoal(int activityId, int goalId);
    }
}
