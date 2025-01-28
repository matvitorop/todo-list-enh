using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("Day")]
    public class Day
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public User User { get; set; } = null!;
        public ICollection<DailyTask> DailyTasks { get; set; } = new List<DailyTask>();
        public ICollection<DailyGoal> DailyGoals { get; set; } = new List<DailyGoal>();
    }

}
