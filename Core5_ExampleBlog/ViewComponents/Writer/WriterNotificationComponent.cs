using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Writer
{
    public class WriterNotificationComponent: ViewComponent
    {
        NotificationManager manager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var query = manager.TGetList();
            return View(query);
        }
    }
}
