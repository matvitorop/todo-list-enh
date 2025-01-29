using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Models.DTO;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ETLDbContext _dbContext;

        public UserRepository(ETLDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddUser(User user)
        {
            user.Password = HashPassword(user.Password);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            if (HashPassword(password)!=user.Password)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> CheckUserByEmail(AddUserDTO userDTO)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
