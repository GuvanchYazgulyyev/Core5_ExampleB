using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Comments
{
    public class CommentLisBlog: ViewComponent
    {
        CommentManager dr = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = dr.GetList(id);
            return View(values);
        }
    }
}
