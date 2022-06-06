using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.OwnWriterPost
{
    public class BlogListDashboard: ViewComponent
    {
        BlogManager bl = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var value = bl.GetBlogWidthCategory();
            return View(value);
        }
    }
}
