namespace todo_list_enh.Server.Models.DTO.Task
{
    public class ActivityTaskDTO
    {
        public TaskDTO Task { get; set; }
        public int ActivityId { get; set; }
        public int order { get; set; }
    }
}
