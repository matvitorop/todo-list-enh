using todo_list_enh.Server.Models.DTO.User;

namespace todo_list_enh.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<(string Token, UserDTO User)?> RegisterAsync(AddUserDTO userDTO);
        Task<(string Token, UserDTO User)?> LoginAsync(AddUserDTO userDTO);
    }
}
