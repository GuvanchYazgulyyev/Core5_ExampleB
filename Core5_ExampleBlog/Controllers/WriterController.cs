using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        // [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
