using Microsoft.AspNetCore.Mvc;
using bloginterior.Models;
using System.Linq;

namespace bloginterior.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BlogDbContext _context;

        public CategoryController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Category.Find(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
