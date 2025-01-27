using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<User> AddUser(User user);
    }
}
