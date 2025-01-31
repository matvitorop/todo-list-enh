using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IDayRepository : IActivityRepository<Day, DailyTask, DailyGoal> { }
}
