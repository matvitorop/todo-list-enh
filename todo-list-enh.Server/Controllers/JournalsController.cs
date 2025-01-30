using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo_list_enh.Server.Extensions;
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
            var userId = this.GetUserIdOrThrowUnauthorized();
            var journalDTO = await _journalService.GetJournalDetailsAsync(journalId, userId);

            return Ok(journalDTO);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddJournal([FromBody] AddJournalDTO journalDTO)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var createdJournalDTO = await _journalService.AddJournalAsync(journalDTO, userId);
            return CreatedAtAction(nameof(GetJournalDetails), new { journalId = createdJournalDTO.Id }, createdJournalDTO);
        }

        [Authorize]
        [HttpDelete]
        [Route("{journalId}")]
        public async Task<IActionResult> DeleteJournal(int journalId)
        {
            var userId = this.GetUserIdOrThrowUnauthorized();

            var success = await _journalService.DeleteJournalAsync(journalId, userId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
