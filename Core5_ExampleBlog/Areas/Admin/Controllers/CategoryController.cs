using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Core5_ExampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager category = new CategoryManager(new EfCategoryRepository());

        // Category List
        public IActionResult Index( int page=1)
        {
            var result = category.TGetList().ToPagedList(page, 10);
            return View(result);
        }

        // Category Add
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        // Category Add
        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {
            CategoryValidator validation = new CategoryValidator();
            ValidationResult validationResult = validation.Validate(c);
            if (validationResult.IsValid)
            {
                c.CategoryStatus = true;
                category.TAdd(c);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
