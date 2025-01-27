using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<Week> Weeks { get; set; } = new List<Week>();
        public ICollection<Day> Days { get; set; } = new List<Day>();
        public ICollection<Journal> Journals { get; set; } = new List<Journal>();
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
