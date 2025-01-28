using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.Journal;
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
            _userRepository = userRepository;
            _mapper = mapper;
            _journalService = journalService;
        }

        [Authorize]
        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetJournalsByUser(int userId)
        {
            var journals = await _journalService.GetJournalsByUserAsync(userId);
            var journalsDTO = _mapper.Map<List<JournalDTO>>(journals);
            return Ok(journalsDTO);
        }

        [Authorize]
        [HttpGet]
        [Route("{userId:int}/{journalId:int}")]
        public async Task<IActionResult> GetJournalDetails(int journalId)
        {
            var journal = await _journalService.GetJournalDetailsAsync(journalId);
            if (journal == null)
            {
                return NotFound();
            }
            var journalDTO = _mapper.Map<JournalDTO>(journal);
            return Ok(journalDTO);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddJournal([FromBody] AddJournalDTO journalDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is missing in the token.");
            }

            var journal = _mapper.Map<Journal>(journalDTO);
            journal.UserId = int.Parse(userId);

            var createdJournal = await _journalService.AddJournalAsync(journal);
            return CreatedAtAction(nameof(GetJournalDetails), new { journalId = createdJournal.Id }, createdJournal);
        }

        [Authorize]
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
