using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ETLDbContext _dbContext;

        public SQLUserRepository (ETLDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
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

            if (!VerifyPassword(password, user.Password))
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
            {
                return null;
            }
            return user;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = SHA256.Create();
            var hashedInput = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashedInput == hashedPassword;
        }
    }
}
