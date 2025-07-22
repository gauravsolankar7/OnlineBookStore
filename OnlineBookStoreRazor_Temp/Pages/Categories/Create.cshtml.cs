using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStoreRazor_Temp.Data;
using OnlineBookStoreRazor_Temp.Models;

namespace OnlineBookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;
        public Category Category { get; set; }

        public CreateModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            db.Categories.Add(Category);
            db.SaveChanges();
            TempData["success"] = "Category created successfully.";
            return RedirectToPage("Index");
        }
    }
}
