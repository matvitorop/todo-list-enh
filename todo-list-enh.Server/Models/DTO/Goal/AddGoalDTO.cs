using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.DTO.Goal
{
    public class AddGoalDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
