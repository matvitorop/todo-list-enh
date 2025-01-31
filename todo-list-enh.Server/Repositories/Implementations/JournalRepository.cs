using Microsoft.EntityFrameworkCore;
using System;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class JournalRepository : Repository<Journal>, IJournalRepository
    {
        private readonly ETLDbContext _dbContext;
        public JournalRepository(ETLDbContext dbContext) : base(dbContext) { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Journal>> GetJournalsByUserIdAsync(int userId)
        {
            return await FindAsync(j => j.UserId == userId);
        }

        public async Task<Journal?> GetJournalWithRecordsAsync(int journalId)
        {
            return await GetWithIncludesAsync(j => j.Id == journalId, j => j.JournalRecords);
        }
    }

}
