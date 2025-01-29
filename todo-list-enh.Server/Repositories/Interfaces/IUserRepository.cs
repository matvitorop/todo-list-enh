using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO.User;

namespace todo_list_enh.Server.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<bool> CheckUserByEmail(AddUserDTO userDTO);
        Task<User> AddUser(User user);
    }
}
