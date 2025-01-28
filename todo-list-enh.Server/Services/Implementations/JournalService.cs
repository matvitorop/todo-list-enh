using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;


namespace todo_list_enh.Server.Services.Implementations
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository _journalRepository;

        public JournalService(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<IEnumerable<Journal>> GetJournalsByUserAsync(int userId)
        {
            return await _journalRepository.GetJournalsByUserIdAsync(userId);
        }

        public async Task<Journal?> GetJournalDetailsAsync(int journalId)
        {
            return await _journalRepository.GetJournalWithRecordsAsync(journalId);
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            journal.CreatedAt = DateTime.UtcNow;
            await _journalRepository.AddAsync(journal);
            return journal;
        }

        public async Task<bool> DeleteJournalAsync(int journalId)
        {
            var journal = await _journalRepository.GetByIdAsync(journalId);
            if (journal == null)
            {
                return false;
            }

            await _journalRepository.DeleteAsync(journal);
            return true;
        }
    }
}
