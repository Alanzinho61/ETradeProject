using ETrade.Core.Service;
using ETrade.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService<Category> _category;
        public HomeController(IDbService<Category> db)
        {
            _category = db;  
        }
        public IActionResult Index()
        {
           
            return View(_category.GetAll());
        }
    }
}
