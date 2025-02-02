namespace todo_list_enh.Server.Models.DTO.Task
{
    public class AddTaskDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsStrict { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
