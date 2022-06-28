using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core5_ExampleBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Core5_ExampleBlog.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager writer = new WriterManager(new EfWriterRepository());
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
        // Writer Update
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context context= new Context();
            var mail = User.Identity.Name;
            var Id = context.Writers.Where(k => k.WriterMail == mail)
                .Select(l => l.WriterID).FirstOrDefault();
            var result = writer.TGetById(Id);
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator rules = new WriterValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                // Burada Manager Devreye Giriyor
                writer.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.msg = "Hata İle Karşılaşıldı!!!";
            return View();
        }

        // Writer Add
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            WriterImageValidator rules = new WriterImageValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
               
                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var image = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImages/", image);
                    var stream = new FileStream(location, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    w.WriterImage = image;
                }
                w.WriterStatus = true;
                w.WriterName = p.WriterName;
                w.WriterAbout = p.WriterAbout;
                w.WriterPassword = p.WriterPassword;
                w.WriterMail = p.WriterMail;
                writer.TAdd(w);
                return RedirectToAction("Index", "Dashboard");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.msg = "Hata İle Karşılaşıldı!!!";
            return View();
        }



    }
}
