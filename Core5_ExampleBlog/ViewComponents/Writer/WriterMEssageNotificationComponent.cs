using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Writer
{
    public class WriterMEssageNotificationComponent: ViewComponent
    {
        AllMessageManager manager = new AllMessageManager(new EfAllMessageRepository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var result = manager.GetUserMessageName(id);
            return View(result);
        }
    }
}
