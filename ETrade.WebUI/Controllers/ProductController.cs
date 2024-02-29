using ETrade.Core.Service;
using ETrade.Model.Entities;
using ETrade.WebUI.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.InteropServices;

namespace ETrade.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDbService<Product> _dbService;
        public ProductController(IDbService<Product> dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View(); //yok
        }
        public IActionResult Details(int id)
        {
            var a = _dbService.Find(id);
            return View(a);
        }
    }
}
