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
        [Route("my")]
        public async Task<IActionResult> GetJournalsByUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is missing in the token.");
            }

            var journals = await _journalService.GetJournalsByUserAsync(int.Parse(userId));
            var journalsDTO = _mapper.Map<List<JournalDTO>>(journals);
            return Ok(journalsDTO);
        }

        [Authorize]
        [HttpGet]
        [Route("{journalId:int}")]
        public async Task<IActionResult> GetJournalDetails(int journalId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is missing in the token.");
            }

            var journal = await _journalService.GetJournalDetailsAsync(journalId);
            if (journal == null || journal.UserId != int.Parse(userId))
            {
                return NotFound("Journal not found or access denied.");
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
        [HttpDelete]
        [Route("{journalId}")]
        public async Task<IActionResult> DeleteJournal(int journalId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is missing in the token.");
            }

            var journal = await _journalService.GetJournalDetailsAsync(journalId);
            if (journal == null || journal.UserId != int.Parse(userId))
            {            
                return NotFound("Journal not found or access denied.");
            }

            var success = await _journalService.DeleteJournalAsync(journalId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
