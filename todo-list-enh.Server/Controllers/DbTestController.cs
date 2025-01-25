using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list_enh.Server.Services;

namespace todo_list_enh.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DatabaseService _databaseService;

        public DbTestController(ILogger<WeatherForecastController> logger, DatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        [HttpGet(Name = "DbTest")]
        public bool Get()
        {
            bool canConnect = _databaseService.TestConnection();
            if (canConnect)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
