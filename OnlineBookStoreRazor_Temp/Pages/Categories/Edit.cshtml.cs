using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStoreRazor_Temp.Data;
using OnlineBookStoreRazor_Temp.Models;

namespace OnlineBookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext db;
        public Category? Category { get; set; }

        public EditModel(AppDbContext db)
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
            if (ModelState.IsValid)
            {
                db.Categories.Update(Category);
                db.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
