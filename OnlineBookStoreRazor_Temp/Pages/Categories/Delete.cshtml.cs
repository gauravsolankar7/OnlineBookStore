using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStoreRazor_Temp.Data;
using OnlineBookStoreRazor_Temp.Models;

namespace OnlineBookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext db;
        public Category? Category { get; set; }

        public DeleteModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = db.Categories.Find(Category.Id);
            if(obj == null)
            {
                return NotFound();
            }
            db.Categories.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToPage("Index");
        }
    }
}
