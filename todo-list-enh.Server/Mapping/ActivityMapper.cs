using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Goal;
using todo_list_enh.Server.Models.DTO.Journal;
using todo_list_enh.Server.Models.DTO.Task;

namespace todo_list_enh.Server.Mapping
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper()
        {
            CreateMap<AddActivityDTO, Week>();

            CreateMap<AddActivityDTO, Day>();

            CreateMap<AddTaskDTO, Models.Domain.Task>();

            CreateMap<Goal, GoalDTO>();
            
            CreateMap<AddGoalDTO, Goal>();

            //CreateMap<IEnumerable<DailyTask>, >();
        }
    }
}
