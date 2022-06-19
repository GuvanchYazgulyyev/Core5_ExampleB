using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Writer
{
    public class WriterMEssageNotificationComponent: ViewComponent
    {
        MessageManager manager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "mm.yaz@gmail.com";
            var result = manager.TGetInboxByWriter(p);
            return View(result);
        }
    }
}
