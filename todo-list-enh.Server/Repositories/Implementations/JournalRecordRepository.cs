using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class JournalRecordRepository : Repository<JournalRecord>, IJournalRecordRepository
    {
        public JournalRecordRepository(ETLDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<JournalRecord>> GetRecordsByJournalIdAsync(int journalId)
        {
            return await FindAsync(r => r.JournalId == journalId);
        }
        public async System.Threading.Tasks.Task DeleteRecordsByJournalIdAsync(int journalId)
        {
            await DeleteWhereAsync(r => r.JournalId == journalId);
        }
    }
}
