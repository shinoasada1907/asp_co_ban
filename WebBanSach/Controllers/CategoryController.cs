using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objecategoryList = _db.Categories.ToList();
            return View(objecategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]//Chống giả mạo về method tránh hacker tấn công vào phương thức của website
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The name must not same display order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Create Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categryfromDb = _db.Categories.Find(id);
            //var categryfromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categryfromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categryfromDb == null)
            {
                return NotFound();
            }
            return View(categryfromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Chống giả mạo về method tránh hacker tấn công vào phương thức của website
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The name must not same display order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Update Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.Categories.Find(id);
            //var categryfromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categryfromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]//Chống giả mạo về method tránh hacker tấn công vào phương thức của website
        public IActionResult DeletePOST(int? id)
        {
            var categoryfromDb = _db.Categories.Find(id);
            //var categryfromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categryfromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(categoryfromDb);
                _db.SaveChanges();
                TempData["Success"] = "Category Delete Successfully";
                return RedirectToAction("Index");
            }

        }
    }
}
