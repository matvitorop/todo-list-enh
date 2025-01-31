using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IDayRepository : IRepository<Day>
    {
        Task<IEnumerable<DailyTask>> GetAllDailyTasks(int dayId);
        Task<IEnumerable<DailyGoal>> GetAllDailyGoals(int dayId);
        Task<IEnumerable<DailyTask>> GetAllNotOverdueTasks(int dayId);
        Task<IEnumerable<DailyGoal>> GetAllNotOverdueGoals(int dayId);
        Task<bool> DeleteDailyTask(int dayId, int taskId);
        Task<bool> DeleteDailyGoal(int dayId, int taskId);
        Task<bool> ChangeDailyTaskOrder(int dayId, int taskIdToReplace, int taskIdToRemove);
    }
}
