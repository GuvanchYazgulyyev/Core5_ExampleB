using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // Admin Nav Bar Top Parial
        public PartialViewResult AdminNavBarPartial()
        {
            return PartialView();
        }

        // Admin Footer Parial
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
    }
}
