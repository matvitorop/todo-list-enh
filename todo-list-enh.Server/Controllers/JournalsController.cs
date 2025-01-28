using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJournalService _journalService;

        public JournalsController(IUserRepository userRepository, IMapper mapper, IJournalService journalService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._journalService = journalService;
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetJournalsByUser(int userId)
        {
            var journals = await _journalService.GetJournalsByUserAsync(userId);
            return Ok(journals);
        }

        [HttpGet]
        [Route("{userId:int}/{journalId:int}")]
        public async Task<IActionResult> GetJournalDetails(int journalId)
        {
            var journal = await _journalService.GetJournalDetailsAsync(journalId);
            if (journal == null)
            {
                return NotFound();
            }
            return Ok(journal);
        }

        [HttpPost]
        public async Task<IActionResult> AddJournal([FromBody] Journal journal)
        {
            var createdJournal = await _journalService.AddJournalAsync(journal);
            return CreatedAtAction(nameof(GetJournalDetails), new { journalId = createdJournal.Id }, createdJournal);
        }

        [HttpDelete("{journalId}")]
        public async Task<IActionResult> DeleteJournal(int journalId)
        {
            var success = await _journalService.DeleteJournalAsync(journalId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
