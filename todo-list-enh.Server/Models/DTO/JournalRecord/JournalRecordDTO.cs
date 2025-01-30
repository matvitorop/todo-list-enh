using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.DTO.JournalRecord
{
    public class JournalRecordDTO
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime RecordDate { get; set; }
    }
}
