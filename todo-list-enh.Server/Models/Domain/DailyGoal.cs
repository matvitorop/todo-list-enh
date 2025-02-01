using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("DailyGoal")]
    public class DailyGoal
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Day")]
        public int periodId { get; set; }

        [ForeignKey("Goal")]
        public int GoalId { get; set; }

        public Day Day { get; set; } = null!;
        public Goal Goal { get; set; } = null!;
    }

}
