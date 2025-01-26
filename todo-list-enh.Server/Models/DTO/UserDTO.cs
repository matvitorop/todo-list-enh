using todo_list_enh.Server.Models.Domain;
using Task = todo_list_enh.Server.Models.Domain.Task;

namespace todo_list_enh.Server.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
