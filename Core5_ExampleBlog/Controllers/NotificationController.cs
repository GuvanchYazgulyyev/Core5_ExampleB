using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
