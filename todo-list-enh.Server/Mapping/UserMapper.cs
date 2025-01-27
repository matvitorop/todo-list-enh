using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO;

namespace todo_list_enh.Server.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserDTO>();
        }

    }
}
