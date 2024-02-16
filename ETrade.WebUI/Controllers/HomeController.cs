using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
