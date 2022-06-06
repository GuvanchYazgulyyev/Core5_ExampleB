using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core5_ExampleBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blg = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blg.GetBlogWidthCategory();
            return View(values);
        }

        // blog detais

        public IActionResult BlogDetails(int id)
        {
            // Send id
            ViewBag.i = id;
            var value = blg.GetBlogById(id);
            return View(value);
        }


        //  Just List Own Writer Blogs
        public IActionResult BlogListByWriter()
        {
            var values = blg.GetListWidthCategoryByWriter(2);
            return View(values);
        }

        // Add Auther Blogs
        [HttpGet]
        public IActionResult AddBlogAuthet()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> listItems = (from x in categoryManager.TGetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();

            ViewBag.category = listItems;
            return View();
        }
        // For Added Blog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBlogAuthet(Blog b, IFormFile userPicture)
        {
            AddBlogValidation validation = new AddBlogValidation();
            ValidationResult validationResult = validation.Validate(b);
            if (validationResult.IsValid)
            {
                b.BlogStatus = true;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterID = 2;

                // Resim Kaydetme----------------------------------------------
                if (userPicture.Length > 0)
                {
                    // Resim Yolunu buluyor
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
                    // Veri tabanı yolunu buluyor
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture/", fileName);
                    // Kaydetmek için
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        userPicture.CopyToAsync(stream);
                        b.BlogImage = fileName;
                    }
                }
                blg.TAdd(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        // For Deleted Blog
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blg.TGetById(id);
            blg.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }


        // For Edit
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> listItems = (from x in categoryManager.TGetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();

            ViewBag.category = listItems;
            var value = blg.TGetById(id);
            return View(value);
        }
        // For Edit
        [HttpPost]
        public IActionResult EditBlog(Blog b, IFormFile userPicture, IFormFile userPicture2)
        {
            // Resim Kaydetme----------------------------------------------
            if (userPicture != null && userPicture.Length > 0)
            {
                // Resim Yolunu buluyor
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
                // Veri tabanı yolunu buluyor
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture/", fileName);
                // Kaydetmek için
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    userPicture.CopyToAsync(stream);
                    b.BlogImage = fileName;
                }
            }

            // Resim Kaydetme Küçük Resim----------------------------------------------
            if (userPicture2 != null && userPicture2.Length > 0)
            {
                // Resim Yolunu buluyor
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture2.FileName);
                // Veri tabanı yolunu buluyor
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture/", fileName);
                // Kaydetmek için
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    userPicture2.CopyToAsync(stream);
                    b.BlogThumbnailImage = fileName;
                }
            }


            b.WriterID = 2;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            b.BlogStatus = true;
            blg.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
