using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IJournalService
    {
        Task<IEnumerable<Journal>> GetJournalsByUserAsync(int userId);
        Task<Journal?> GetJournalDetailsAsync(int journalId);
        Task<Journal> AddJournalAsync(Journal journal);
        Task<bool> DeleteJournalAsync(int journalId);
    }

}
