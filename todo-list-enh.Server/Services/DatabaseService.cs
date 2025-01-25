using System;
using todo_list_enh.Server.Data;

namespace todo_list_enh.Server.Services
{
    public class DatabaseService
    {
        private readonly ETLDbContext _dbContext;

        public DatabaseService(ETLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool TestConnection()
        {
            try
            {
                _dbContext.Database.CanConnect();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не вдалося підключитися до бази даних: {ex.Message}");
                return false;
            }
        }
    }

}
