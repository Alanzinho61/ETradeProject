using ETrade.Core.Entity;
using ETrade.Core.Service;
using ETrade.Model.Entities;
using ETrade.Service.DbService;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IDbService<Category> _db;

        public CategoryController(IDbService<Category> db)
        {
            _db = db;     
        }
        public IActionResult Index()
        {
            return View(_db.GetAll());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (category !=null)
            {
                _db.Add(category);
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public IActionResult Update(int id) 
        {
            return View(_db.Find(id));
        }
        [HttpPost]
        public IActionResult Update(Category c)
        {
            if (c != null)
            {
                _db.Update(c);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id>0)
            {
                _db.Remove(_db.Find(id));
                return RedirectToAction("Index");
            }
            return View("Index", _db.GetAll());
        }


    }
}
