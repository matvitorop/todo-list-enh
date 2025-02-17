using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public bool IsStrict { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public User User { get; set; } = null!;
        
        [JsonIgnore]
        public ICollection<DailyTask> DailyTasks { get; set; } = new List<DailyTask>();
        [JsonIgnore]
        public ICollection<WeekTask> WeekTasks { get; set; } = new List<WeekTask>();
    }

}
