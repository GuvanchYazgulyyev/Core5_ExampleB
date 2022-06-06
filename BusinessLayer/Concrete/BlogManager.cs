using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogWidthCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        // Yazarın Bloglarının yanında Kategorileri getir
        public List<Blog> GetListWidthCategoryByWriter(int id)
        {
            return _blogDal.GetListWidthCategoryByWriter(id);
        }

        //public Blog GetById(int id)
        //{
        //    return _blogDal.GetByID(id);
        //}

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(k => k.BlogID == id);
        }

        //public List<Blog> GetList()
        //{
        //    return _blogDal.GetListAll();
        //}

        public List<Blog> GetListWdthWriter(int id)
        {
            return _blogDal.GetListAll(k => k.WriterID == id);
        }

        // Sadece 3 blogu getirir Footer Kısmı için
        public List<Blog> GetList3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }


        // New Added From Business Layer From GenericServise
        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetListAll();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void Passive(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
