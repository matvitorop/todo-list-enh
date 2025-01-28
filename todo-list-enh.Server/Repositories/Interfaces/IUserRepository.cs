using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<User> AddUser(User user);
        Task<bool> CheckUserByEmail(AddUserDTO userDTO);
    }
}
