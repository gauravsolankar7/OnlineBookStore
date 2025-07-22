using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStoreRazor_Temp.Data;
using OnlineBookStoreRazor_Temp.Models;

namespace OnlineBookStoreRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        public List<Category> CategoryList{ get; set; }

        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            CategoryList =  db.Categories.ToList();
        }
    }
}
