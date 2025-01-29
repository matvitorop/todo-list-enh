using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo_list_enh.Server.Models.DTO.JournalRecord;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Controllers
{
    [ApiController]
    [Route("api/journals/{journalId:int}/records")]
    public class JournalRecordsController : ControllerBase
    {
        private readonly IJournalRecordService _journalRecordService;

        public JournalRecordsController(IJournalRecordService journalRecordService)
        {
            _journalRecordService = journalRecordService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRecordsByJournal(int journalId)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized("User ID is missing in the token.");

            var recordsDTO = await _journalRecordService.GetRecordsByJournalAsync(journalId, userId.Value);
            return Ok(recordsDTO);
        }

        [Authorize]
        [HttpGet("{recordId:int}")]
        public async Task<IActionResult> GetRecordDetails(int journalId, int recordId)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized("User ID is missing in the token.");

            var recordDTO = await _journalRecordService.GetRecordDetailsAsync(recordId, userId.Value);
            return recordDTO != null ? Ok(recordDTO) : NotFound("Record not found or access denied.");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRecord(int journalId, [FromBody] AddJournalRecordDTO recordDTO)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized("User ID is missing in the token.");

            recordDTO.JournalId = journalId;
            var createdRecord = await _journalRecordService.AddRecordAsync(recordDTO, userId.Value);
            return CreatedAtAction(nameof(GetRecordDetails), new { journalId, recordId = createdRecord.Id }, createdRecord);
        }

        [Authorize]
        [HttpDelete("{recordId:int}")]
        public async Task<IActionResult> DeleteRecord(int journalId, int recordId)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized("User ID is missing in the token.");

            var success = await _journalRecordService.DeleteRecordAsync(recordId, userId.Value);
            return success ? NoContent() : NotFound("Record not found or access denied.");
        }

        private int? GetUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdStr, out var userId) ? userId : null;
        }
    }
}
