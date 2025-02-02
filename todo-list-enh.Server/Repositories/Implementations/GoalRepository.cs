using todo_list_enh.Server.Data;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class GoalRepository : Repository<Models.Domain.Goal>, IGoalRepository
    {
        public GoalRepository(ETLDbContext dbContext) : base(dbContext) { }
    }
}
