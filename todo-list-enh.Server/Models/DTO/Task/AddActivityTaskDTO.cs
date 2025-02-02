namespace todo_list_enh.Server.Models.DTO.Task
{
    public class AddActivityTaskDTO
    {
        public AddTaskDTO AddTask { get; set; }
        public int ActivityId { get; set; }
        public int order { get; set; }
    }
}
