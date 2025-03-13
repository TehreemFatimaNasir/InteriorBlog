using Microsoft.AspNetCore.Mvc;
using bloginterior.Models;
using System.Linq;

namespace bloginterior.Controllers
{
    public class CommentController : Controller
    {
        private readonly BlogDbContext _context;

        public CommentController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment c)
        {
            _context.Comment.Add(c);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Details(int id)
        {
            var comment = _context.Comment.Where(x => x.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        public IActionResult Edit(int id)
        {
            var comment = _context.Comment.Where(x => x.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        public IActionResult Edit(Comment c)
        {
            _context.Comment.Update(c);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult Delete(int id)
        {
            var comment = _context.Comment.Where(x => x.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _context.Comment.Where(x => x.Id == id).FirstOrDefault();
            if (comment != null)
            {
                _context.Comment.Remove(comment);
                _context.SaveChanges();
            }
            return View("Index");
        }
    }
}
