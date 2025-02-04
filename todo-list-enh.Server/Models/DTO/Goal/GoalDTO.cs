using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Models.DTO.Goal
{
    public class GoalDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<WeekGoal> WeekGoals { get; set; } = new List<WeekGoal>();
        public ICollection<DailyGoal> DailyGoals { get; set; } = new List<DailyGoal>();
    }
}
