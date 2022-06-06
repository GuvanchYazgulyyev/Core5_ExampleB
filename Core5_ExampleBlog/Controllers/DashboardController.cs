using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core5_ExampleBlog.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context dr = new Context();
            ViewBag.q1 = dr.Blogs.Count().ToString();
            ViewBag.q3 = dr.Categories.Count().ToString();
            ViewBag.q2 = dr.Blogs.Where(k => k.WriterID == 2).Count();
            return View();
        }
    }
}
