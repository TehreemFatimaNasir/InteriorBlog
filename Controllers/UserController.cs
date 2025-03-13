using bloginterior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace bloginterior.Controllers
{
    public class UserController : Controller
    {
        private readonly BlogDbContext _context;

        public UserController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            _context.User.Add(u);
            _context.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var check = _context.User.Where(x => x.email == u.email && x.password == u.password).FirstOrDefault();

            if (check != null)
            {
                HttpContext.Session.SetString("username", check.username);

                string name = HttpContext.Session.GetString("username");
                ViewBag.username = name;

                return View("Index");
            }
            else
            {
                ViewBag.error = "Invalid email or password";
                return View();
            }
        }




    }
}
