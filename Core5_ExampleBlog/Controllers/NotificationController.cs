using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notification = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AllNotifications()
        {
            var result = notification.TGetList();
            return View(result);
        }
    }
}
