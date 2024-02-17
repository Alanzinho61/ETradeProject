using ETrade.Core.Service;
using ETrade.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IDbService<Product> _db;
        private readonly IDbService<Category> _Categorydb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IDbService<Product> db, IDbService<Category> ctb, IWebHostEnvironment cd)
        {
            _db = db;
            _Categorydb = ctb;
            _webHostEnvironment = cd;
        }
        public IActionResult Index()
        {
            ViewBag.Category=_Categorydb.GetAll();
            return View(_db.GetAll());
        }


        
        public IActionResult Add()
        {
            ViewBag.Category = _Categorydb.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p, IFormFile image)
        {
            if (p != null)
            {
                
                var downloadImage = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(downloadImage))
                {
                    Directory.CreateDirectory(downloadImage);
                }
                var imagePath = Path.Combine(downloadImage, image.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                p.ImagePath = image.FileName;
                _db.Add(p);
                return RedirectToAction("Index");
            }
            //ViewBag.ErrorAdd = "Ekleme yapilamadi";
            return View();
        }

        public IActionResult Update(int id)
        {
            ViewBag.Category = _Categorydb.GetAll();
            ViewBag.SelectedCategoryId = _db.Find(id).CategoryId;
            return View(_db.Find(id));
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            if(p != null)
            {
                _db.Update(p);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var delProduct=_db.Find(id);
            if (delProduct != null)
            {
                _db.Remove(delProduct);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
