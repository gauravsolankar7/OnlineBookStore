using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreWeb.Data;
using OnlineBookStoreWeb.Models;

namespace OnlineBookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;

        public CategoryController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.ToLower() == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryId = db.Categories.Find(id);
            //Category? categoryId2 = db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryId3 = db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryId = db.Categories.Find(id);

            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            db.Categories.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}
