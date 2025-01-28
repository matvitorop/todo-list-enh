namespace todo_list_enh.Server.Models.DTO.Journal
{
    public class JournalDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
