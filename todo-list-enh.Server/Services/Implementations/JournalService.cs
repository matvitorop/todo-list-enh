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
        private readonly IMapper _mapper;

        public JournalService(IJournalRepository journalRepository, IMapper mapper)
        {
            _journalRepository = journalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JournalDTO>> GetJournalsByUserAsync(int userId)
        {
            var journals = await _journalRepository.GetJournalsByUserIdAsync(userId);
            return _mapper.Map<List<JournalDTO>>(journals);
        }

        public async Task<JournalDTO?> GetJournalDetailsAsync(int journalId)
        {
            var journal = await _journalRepository.GetJournalWithRecordsAsync(journalId);
            if (journal == null)
            {
                return null;
            }
            return _mapper.Map<JournalDTO>(journal);
        }

        public async Task<JournalDTO> AddJournalAsync(AddJournalDTO journalDTO)
        {
            var journal = _mapper.Map<Journal>(journalDTO);
            journal.CreatedAt = DateTime.UtcNow;

            await _journalRepository.AddAsync(journal);
            return _mapper.Map<JournalDTO>(journal);
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
