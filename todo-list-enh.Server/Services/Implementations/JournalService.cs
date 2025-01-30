using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Journal;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;


namespace todo_list_enh.Server.Services.Implementations
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IJournalRecordRepository _journalRecordRepository;
        private readonly IMapper _mapper;

        public JournalService(IJournalRepository journalRepository, IJournalRecordRepository journalRecordRepository, IMapper mapper)
        {
            _journalRepository = journalRepository;
            _journalRecordRepository = journalRecordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JournalDTO>> GetJournalsByUserAsync(int userId)
        {
            var journals = await _journalRepository.GetJournalsByUserIdAsync(userId);
            return _mapper.Map<List<JournalDTO>>(journals);
        }

        public async Task<JournalDTO> GetJournalDetailsAsync(int journalId, int userId)
        {
            var journal = await _journalRepository.GetJournalWithRecordsAsync(journalId);
            if (journal == null || journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");

            return _mapper.Map<JournalDTO>(journal);
        }

        public async Task<JournalDTO> AddJournalAsync(AddJournalDTO journalDTO)
        {
            var journal = _mapper.Map<Journal>(journalDTO);
            journal.CreatedAt = DateTime.UtcNow;

            await _journalRepository.AddAsync(journal);
            return _mapper.Map<JournalDTO>(journal);
        }

        public async Task<bool> DeleteJournalAsync(int journalId, int userId)
        {
            var journal = await _journalRepository.GetByIdAsync(journalId);
            
            if (journal == null) return false;
            if (journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");
            await _journalRecordRepository.DeleteRecordsByJournalIdAsync(journalId);
            await _journalRepository.DeleteAsync(journal);
            return true;
        }
    }
}
