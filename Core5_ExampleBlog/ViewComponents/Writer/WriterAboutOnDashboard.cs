using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core5_ExampleBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard :ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context context= new Context();
        public IViewComponentResult Invoke()
        {
            var mail = User.Identity.Name;
            var Id = context.Writers.Where(k => k.WriterMail == mail)
                .Select(l => l.WriterID).FirstOrDefault();
            var query = wm.GetWriterById(Id);
            return View(query);
        }
    }
}
