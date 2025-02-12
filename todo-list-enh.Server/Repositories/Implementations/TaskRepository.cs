using todo_list_enh.Server.Data;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class TaskRepository : Repository<Models.Domain.Task>, ITaskRepository
    {
        public TaskRepository(ETLDbContext dbContext) : base(dbContext) { }
    }
}