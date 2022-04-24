using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blg = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blg.GetBlogWidthCategory();
            return View(values);
        }

        // blog detais

        public IActionResult BlogDetails(int id)
        {
            // Send id
            ViewBag.i = id;
            var value = blg.GetBlogById(id);
            return View(value);
        }


    }
}
