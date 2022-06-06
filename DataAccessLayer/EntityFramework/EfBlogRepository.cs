using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        // Yazarın Bloglarının yanında Kategorileri getir
        public List<Blog> GetListWidthCategoryByWriter(int id)
        {
          using (var c=new Context())
            {
                return c.Blogs.Include(l => l.Category).Where(l => l.WriterID == id).ToList();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using (var c=new Context())
            {
                return c.Blogs.Include(k => k.Category).ToList();
            }
       
        }
    }
}
