using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(Writer w)
        {
            Context dr = new Context();
            var datavalue = dr.Writers.FirstOrDefault(k => k.WriterMail == w.WriterMail && k.WriterPassword == w.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,w.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
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
