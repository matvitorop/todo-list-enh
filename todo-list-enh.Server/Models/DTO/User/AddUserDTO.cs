namespace todo_list_enh.Server.Models.DTO.User
{
    public class AddUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
