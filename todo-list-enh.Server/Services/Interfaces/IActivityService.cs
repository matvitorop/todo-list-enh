using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Task;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IActivityService<TActivity, TTask>
    {
        Task<bool> AddActivity(AddActivityDTO dto);
        Task<bool> AddActivityTask(TActivity activity, TaskDTO task, int order);
    }
}
