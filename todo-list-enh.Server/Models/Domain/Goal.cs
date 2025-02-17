using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("Goal")]
    public class Goal
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
        
        [JsonIgnore]
        public ICollection<WeekGoal> WeekGoals { get; set; } = new List<WeekGoal>();
        [JsonIgnore]
        public ICollection<DailyGoal> DailyGoals { get; set; } = new List<DailyGoal>();
    }

}
