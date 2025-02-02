using todo_list_enh.Server.Models.DTO.Task;

namespace todo_list_enh.Server.Models.DTO.Goal
{
    public class AddActivityGoalDTO
    {
        public AddGoalDTO AddGoal { get; set; }
        public int ActivityId { get; set; }
    }   
}
