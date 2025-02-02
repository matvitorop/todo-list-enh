using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Goal;
using todo_list_enh.Server.Models.DTO.Task;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IActivityService<TActivity, TTask, TGoal>
    {
        Task<bool> AddActivity(AddActivityDTO dto);
        Task<bool> AddActivityTask(AddTaskDTO task, int activityId, int order);
        Task<bool> AddActivityGoal(AddGoalDTO goal, int activityId/*, data.order*/);
    }
}
