using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core5_ExampleBlog.Controllers
{
    public class CommentController : Controller
    {
        // For Comments
        CommentManager cm = new CommentManager(new EfCommentRepository());

        // For subscribeMailDal
        SubscribeMailManager sub = new SubscribeMailManager(new EfSubscribeMailRepository());


        public IActionResult Index()
        {
            return View();
        }

        // Add Comment 
        [HttpGet]
        public PartialViewResult AddCommentPartial()
        {
            return PartialView();
        }

        // Add Comment 
        [HttpPost]
        public PartialViewResult AddCommentPartial(Comment c)
        {
            AddCommentValidator validationRules = new AddCommentValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {

                c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.CommentStatus = true;
                c.BlogID = 2;
                return PartialView();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return PartialView();
        }



        // List Comments
        public PartialViewResult ListCommentsPartial(int id)
        {

            var values = cm.GetList(id);
            return PartialView(values);
        }

        // Home Page Subscribe Mail 
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(SubscribeMail mail)
        {
            SubscribeMailValidator validationRules = new SubscribeMailValidator();
            ValidationResult result = validationRules.Validate(mail);
            if (result.IsValid)
            {
                mail.MailStatus = true;
                sub.AddSubscribeMail(mail);
                return PartialView();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return PartialView();
        }





    }
}
