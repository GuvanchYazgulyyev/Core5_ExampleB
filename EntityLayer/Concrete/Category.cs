using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{

    // Somut Öğeler
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [AllowHtml]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        // İlişki
        // Bir Kategorinin Birden fazla Blogu Olabilirs
        public List<Blog> Blogs { get; set; }
    }
}
