using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.OwnWriterPost
{
    public class WriterPost: ViewComponent
    {
        BlogManager b = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var value = b.GetListWdthWriter(2);
            return View(value);
        }
    }
}
