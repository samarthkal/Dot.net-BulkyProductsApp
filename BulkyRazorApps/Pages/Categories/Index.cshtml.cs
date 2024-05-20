using BulkyRazorApps.Data;
using BulkyRazorApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyRazorApps.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;
        public List<Category> categoriList { get; set; }
        public IndexModel(AppDbContext dbContext)
        {
            db = dbContext;
        }
        public void OnGet()
        {
            categoriList= db.Categories.ToList();
        }
    }
}
