using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Category
{
    public class CategoryListComponent:ViewComponent
    {
        CategoryManager dr = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var value = dr.GetList();
            return View(value);
        }
    }
}
