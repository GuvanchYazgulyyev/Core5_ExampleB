using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Category
{
    public class CategoryListDashboard: ViewComponent
    {
        CategoryManager category = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var value = category.TGetList();
            return View(value);
        }
    }
}
