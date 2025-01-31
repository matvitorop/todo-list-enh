using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IWeekRepository : IRepository<Week>
    {
        Task<IEnumerable<WeekTask>> GetAllWeekTasks(int weekId);
        Task<IEnumerable<WeekGoal>> GetAllWeekGoals(int weekId);
        Task<IEnumerable<WeekTask>> GetAllNotOverdueTasks(int weekId);
        Task<IEnumerable<WeekGoal>> GetAllNotOverdueGoals(int weekId);
        Task<bool> DeleteWeekTask(int weekId,int taskId);
        Task<bool> DeleteWeekGoal(int weekId, int taskId);
        Task<bool> ChangeWeekTaskOrder(int weekId, int taskIdToReplace, int taskIdToRemove);
    }
}
