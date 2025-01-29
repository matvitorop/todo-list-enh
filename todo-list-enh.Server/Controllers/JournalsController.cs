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
        private readonly IJournalService _journalService;

        public JournalsController(IJournalService journalService)
        {
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

            var journalsDTO = await _journalService.GetJournalsByUserAsync(int.Parse(userId));
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

            var journalDTO = await _journalService.GetJournalDetailsAsync(journalId);
            if (journalDTO == null || journalDTO.UserId != int.Parse(userId))
            {
                return NotFound("Journal not found or access denied.");
            }

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

            var createdJournalDTO = await _journalService.AddJournalAsync(journalDTO);
            return CreatedAtAction(nameof(GetJournalDetails), new { journalId = createdJournalDTO.Id }, createdJournalDTO);
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
