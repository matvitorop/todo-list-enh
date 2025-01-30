using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Journal;
using todo_list_enh.Server.Models.DTO.JournalRecord;

namespace todo_list_enh.Server.Mapping
{
    public class JournalRecordMapper : Profile
    {
        public JournalRecordMapper()
        {
            CreateMap<JournalRecord, JournalRecordDTO>();
            CreateMap<AddJournalRecordDTO, JournalRecord>();
        }
    }
}
