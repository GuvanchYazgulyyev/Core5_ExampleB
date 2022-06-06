using Microsoft.AspNetCore.Mvc;

namespace Core5_ExampleBlog.ViewComponents.Writer
{
    public class WriterNotificationComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
