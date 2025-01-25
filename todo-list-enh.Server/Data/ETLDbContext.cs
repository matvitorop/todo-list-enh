using Microsoft.EntityFrameworkCore;
using todo_list_enh.Server.Models.Domain;

namespace todo_list_enh.Server.Data
{
    public class ETLDbContext : DbContext
    {
        public ETLDbContext (DbContextOptions contextOptions) : base (contextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
