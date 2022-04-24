using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
