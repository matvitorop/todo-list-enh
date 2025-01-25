using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    public class DailyTask
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Day")]
        public int DayId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public int Order { get; set; }

        public Day Day { get; set; } = null!;
        public Task Task { get; set; } = null!;
    }

}
