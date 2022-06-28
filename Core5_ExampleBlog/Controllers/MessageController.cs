using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.Controllers
{
    public class MessageController : Controller
    {
      AllMessageManager allMessages = new AllMessageManager(new EfAllMessageRepository());
        public IActionResult Inbox()
        {
            int id = 2;
            var result = allMessages.GetUserMessageName(id);
            return View(result);
        }

        // Mesaj Detay
        // For Edit
        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
           
            var value = allMessages.TGetById(id);
            return View(value);
        }

    }
}
