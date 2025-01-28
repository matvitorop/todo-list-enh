using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("Week")]
    public class Week
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public User User { get; set; } = null!;
        public ICollection<WeekGoal> WeekGoals { get; set; } = new List<WeekGoal>();
        public ICollection<WeekTask> WeekTasks { get; set; } = new List<WeekTask>();
    }

}
