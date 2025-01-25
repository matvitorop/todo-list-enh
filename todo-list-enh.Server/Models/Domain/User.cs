namespace todo_list_enh.Server.Models.Domain
{
    public class User
    {
        public required Guid id { get; set; }
        public required string username { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public DateTime createdAt { get; set; }
    }
}
