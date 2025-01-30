using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Journal;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IJournalService
    {
        Task<IEnumerable<JournalDTO>> GetJournalsByUserAsync(int userId);
        Task<JournalDTO> GetJournalDetailsAsync(int journalId, int userId);
        Task<JournalDTO> AddJournalAsync(AddJournalDTO journal);
        Task<bool> DeleteJournalAsync(int journalId, int userId);
    }

}
