using Microsoft.AspNetCore.Mvc;
using bloginterior.Models;
using System.Linq;

namespace bloginterior.Controllers
{
    public class BlogpostController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogpostController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogposts = _context.BlogPost.ToList();
            return View(blogposts);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlogPost blogpost)
        {
            _context.BlogPost.Add(blogpost);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var blogpost = _context.BlogPost.Find(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return View(blogpost);
        }

        [HttpPost]
        public IActionResult Edit(BlogPost blogpost)
        {
            _context.BlogPost.Update(blogpost);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Delete(int id)
        {
            var blogpost = _context.BlogPost.Find(id);
            if (blogpost != null)
            {
                _context.BlogPost.Remove(blogpost);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Comments(int postId)
        {
            var comments = _context.Comment.Where(c => c.Id == postId).ToList();
            return View(comments);
        }
        public IActionResult Details(int id)
        {
            var blogpost = _context.BlogPost.Find(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return View(blogpost);
        }

    }
}
