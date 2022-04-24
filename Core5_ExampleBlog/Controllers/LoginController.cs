using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core5_ExampleBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Writer w)
        {
            Context dr = new Context();
            var value = dr.Writers.FirstOrDefault(k => k.WriterMail == w.WriterMail && k.WriterPassword == w.WriterPassword);
            if (value != null)
            {
                HttpContext.Session.SetString("username", w.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }


        }





        //public IActionResult Exam()
        //{
        //    WriterValidator validationRules = new WriterValidator();
        //    ValidationResult result = validationRules.Validate(w);
        //    Context dr = new Context();
        //    var value = dr.Writers.FirstOrDefault(k => k.WriterMail == w.WriterMail
        //    && k.WriterPassword == w.WriterPassword);
        //    if (value != null && result.IsValid)
        //    {
        //        HttpContext.Session.SetString("username", w.WriterMail);
        //        return RedirectToAction("Index", "Writer");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}


    }
}
