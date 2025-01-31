using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Journal;

namespace todo_list_enh.Server.Mapping
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper()
        {
            CreateMap<AddActivityDTO, Week>();

            CreateMap<AddActivityDTO, Day>();
        }
    }
}
