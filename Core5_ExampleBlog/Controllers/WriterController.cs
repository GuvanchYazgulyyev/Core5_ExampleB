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

        public IActionResult WriterProfil()
        {
            return View();
        }


        public IActionResult WriterMail()
        {
            return View();
        }

        // Writer Nav Bar Top Parial
        public PartialViewResult WriterNavBarPartial()
        {
            return PartialView();
        }

         // Writer Footer Parial
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        public IActionResult Test()
        {
            return View();
        }



    }
}
