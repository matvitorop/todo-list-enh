using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("JournalRecord")]
    public class JournalRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Journal")]
        public int JournalId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime RecordDate { get; set; }

        public Journal Journal { get; set; } = null!;
    }

}
