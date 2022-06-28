using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core5_ExampleBlog.Areas.Admin.ViewComponents.Statistic
{
    public class DataStatistic4:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Blogs.OrderByDescending(s => s.BlogID).Select(k => k.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = context.Blogs.OrderByDescending(s => s.BlogID).Select(k => k.BlogCreateDate).Take(1).FirstOrDefault();
            ViewBag.v2 = context.Comments.Count();
            return View();
        }
    }
}
