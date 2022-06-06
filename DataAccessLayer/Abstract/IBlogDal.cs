using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();

        // Yazarın Bloglarının yanında Kategorileri getir
        List<Blog> GetListWidthCategoryByWriter(int id);
    }
}
