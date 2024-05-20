using BulkyProductsApp.Data;
using BulkyProductsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace BulkyProductsApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;
        public CategoryController(AppDbContext dbContext)
        {
            db = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> list = db.Categories.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? formdb = db.Categories.Find(id);
            // db.Categories.FirstOrDefault(x => x.Id == id);
             // db.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (formdb == null)
            {
                return NotFound();
            }

            return View(formdb);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                TempData["success"] = "Category Update successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? formdb = db.Categories.Find(id);
       
            if (formdb == null)
            {
                return NotFound();
            }

            return View(formdb);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {

            Category? formdb = db.Categories.Find(id);
            if (formdb == null)
            {
                return NotFound();
            }
            db.Categories.Remove(formdb);
            db.SaveChanges();
            TempData["success"] = "Category Delete successfully";
            return RedirectToAction("Index");
        }

        }
}
