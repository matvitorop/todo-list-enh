using todo_list_enh.Server.Models.DTO.JournalRecord;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IJournalRecordService
    {
        Task<IEnumerable<JournalRecordDTO>> GetRecordsByJournalAsync(int journalId, int userId);
        Task<JournalRecordDTO?> GetRecordDetailsAsync(int recordId, int userId);
        Task<JournalRecordDTO> AddRecordAsync(AddJournalRecordDTO recordDTO, int userId);
        Task<bool> DeleteRecordAsync(int recordId, int userId);
    }
}
