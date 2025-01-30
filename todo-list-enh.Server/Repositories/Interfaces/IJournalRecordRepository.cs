using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IJournalRecordRepository : IRepository<JournalRecord>
    {
        Task<IEnumerable<JournalRecord>> GetRecordsByJournalIdAsync(int journalId);
        System.Threading.Tasks.Task DeleteRecordsByJournalIdAsync(int journalId);

    }
}
