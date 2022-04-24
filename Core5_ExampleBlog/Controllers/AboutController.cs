using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core5_ExampleBlog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager(new EfAboutRepository());
        ContactManager cont = new ContactManager(new EfContactRepository());

        public IActionResult Index()
        {
            var value = ab.GetList();
            return View(value);
        }

        // Sosial Media About

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }




        /// Contact
        /// 
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact c)
        {
            ContactSendMessageValidator validationRules = new ContactSendMessageValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                c.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.ContactStatus = true;
                cont.CutomSendMessage(c);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



    }
}
