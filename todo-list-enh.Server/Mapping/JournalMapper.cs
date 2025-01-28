using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Journal;

namespace todo_list_enh.Server.Mapping
{
    public class JournalMapper : Profile
    {
        public JournalMapper()
        {
            CreateMap<Journal, JournalDTO>();
            CreateMap<AddJournalDTO, Journal>();
        }
    }
}
