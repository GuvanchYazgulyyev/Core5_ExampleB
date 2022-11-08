using Core5_ExampleBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core5_ExampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonresult = JsonConvert.SerializeObject(writers);
            return Json(jsonresult);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Kıvanç"
            },
            new WriterClass
            {
                Id=2,
                Name="Mekan"
            }
        };
    }
}
