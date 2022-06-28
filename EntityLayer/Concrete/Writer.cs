using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        [AllowHtml]
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }

        // Bir Yazarın Birden fazla Blogu Olabilir
        public List<Blog> Blogs { get; set; }

        public virtual ICollection<AllMessage> SenderMessage { get; set; }
        public virtual ICollection<AllMessage> ReceiverMessage { get; set; }
    }
}
