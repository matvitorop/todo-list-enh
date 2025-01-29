using AutoMapper;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.JournalRecord;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Services.Implementations
{
    public class JournalRecordService : IJournalRecordService
    {
        private readonly IJournalRecordRepository _journalRecordRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IMapper _mapper;

        public JournalRecordService(
            IJournalRecordRepository journalRecordRepository,
            IJournalRepository journalRepository,
            IMapper mapper)
        {
            _journalRecordRepository = journalRecordRepository;
            _journalRepository = journalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JournalRecordDTO>> GetRecordsByJournalAsync(int journalId, int userId)
        {
            var journal = await _journalRepository.GetByIdAsync(journalId);
            if (journal == null || journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");

            var records = await _journalRecordRepository.GetRecordsByJournalIdAsync(journalId);
            return _mapper.Map<List<JournalRecordDTO>>(records);
        }

        public async Task<JournalRecordDTO?> GetRecordDetailsAsync(int recordId, int userId)
        {
            var record = await _journalRecordRepository.GetByIdAsync(recordId);
            if (record == null) return null;

            var journal = await _journalRepository.GetByIdAsync(record.JournalId);
            if (journal == null || journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");

            return _mapper.Map<JournalRecordDTO>(record);
        }

        public async Task<JournalRecordDTO> AddRecordAsync(AddJournalRecordDTO recordDTO, int userId)
        {
            var journal = await _journalRepository.GetByIdAsync(recordDTO.JournalId);
            if (journal == null || journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");

            var record = _mapper.Map<JournalRecord>(recordDTO);
            record.RecordDate = DateTime.UtcNow;

            await _journalRecordRepository.AddAsync(record);
            return _mapper.Map<JournalRecordDTO>(record);
        }

        public async Task<bool> DeleteRecordAsync(int recordId, int userId)
        {
            var record = await _journalRecordRepository.GetByIdAsync(recordId);
            if (record == null) return false;

            var journal = await _journalRepository.GetByIdAsync(record.JournalId);
            if (journal == null || journal.UserId != userId)
                throw new UnauthorizedAccessException("Access denied.");

            await _journalRecordRepository.DeleteAsync(record);
            return true;
        }
    }
}
