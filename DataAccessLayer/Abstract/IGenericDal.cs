using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T: class
    {
        // Add
        void Insert(T t);
        // Delete
        void Delete(T t);

          // Passive
        void Passive(T t);


        // Update
        void Update(T t);

        // all List
        List<T> GetListAll();

        // Get Just ID
        T GetByID(int id);

        //  İd ye göre listeles
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
