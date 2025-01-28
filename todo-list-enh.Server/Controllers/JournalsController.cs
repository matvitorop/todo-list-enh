using Microsoft.AspNetCore.Mvc;

namespace todo_list_enh.Server.Controllers
{
    public class JournalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
