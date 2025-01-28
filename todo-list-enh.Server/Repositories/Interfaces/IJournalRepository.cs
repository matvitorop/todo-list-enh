using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IJournalRepository : IRepository<Journal>
    {
        Task<IEnumerable<Journal>> GetJournalsByUserIdAsync(int userId);
        Task<Journal?> GetJournalWithRecordsAsync(int journalId);
    }
}
