using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Data
{
    public class ETLDbContext : DbContext
    {
        public ETLDbContext (DbContextOptions contextOptions) : base (contextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalRecord> JournalRecords { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<WeekTask> WeekTasks { get; set; }
        public DbSet<DailyGoal> DailyGoals { get; set; }
        public DbSet<WeekGoal> WeekGoals { get; set; }

    }
}
