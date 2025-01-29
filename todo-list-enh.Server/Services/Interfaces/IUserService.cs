using todo_list_enh.Server.Models.DTO;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<(string Token, string Username)?> RegisterAsync(AddUserDTO userDTO);
        Task<(string Token, UserDTO User)?> LoginAsync(AddUserDTO userDTO);
    }

}
