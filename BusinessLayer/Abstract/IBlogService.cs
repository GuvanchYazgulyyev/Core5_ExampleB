using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> GetList();
        Blog GetById(int id);

        // Get Just Category Name
        List<Blog> GetBlogWidthCategory();

        // Get Just Writer Blogs and Posts
        List<Blog> GetListWdthWriter(int id);
    }
}
