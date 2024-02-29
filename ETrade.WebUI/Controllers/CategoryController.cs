using ETrade.Core.Service;
using ETrade.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDbService<Product> _product;
        public CategoryController(IDbService<Product> product)
        {
            _product = product;    
        }
        public IActionResult Index()
        {
            return View(_product.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            var a=_product.GetAll().Where(x=>x.CategoryId==id).ToList();
            return View(a);
        }
    }
}
