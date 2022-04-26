using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.OwnWriterPost
{
    /// <summary>
    /// Burası Footer Bloglar için sAdece 3 blogu getir
    /// </summary>
    public class Footer3Blog:ViewComponent
    {
        BlogManager b = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var value = b.GetList3Blog();
            return View(value);
        }
    }
}
