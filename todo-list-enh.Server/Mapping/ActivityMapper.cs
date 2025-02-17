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

            CreateMap<Week, ActivityDTO>();

            CreateMap<Day, ActivityDTO>();

            // TASKS 
            CreateMap<AddTaskDTO, Models.Domain.Task>();

            CreateMap<Models.Domain.Task, WeekTask>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Models.Domain.Task, DailyTask>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            
            //GOALS
            CreateMap<Goal, GoalDTO>();
            
            CreateMap<AddGoalDTO, Goal>();

            CreateMap<Goal, WeekGoal>()
                .ForMember(dest => dest.GoalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
            CreateMap<Goal, DailyGoal>()
                .ForMember(dest => dest.GoalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
