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
    // Mesaj Gönderen Veri Getirme Ksımı
    public class EfAllMessageRepository:GenericRepository<AllMessage>, AllMessageDal
    {
        public List<AllMessage> GetUserMessageName(int id)
        {
            using (var c=new Context())
            {
                return c.AllMessages.Include(k => k.SenderUser).Where(f => f.ReceiverId == id).ToList();
            }
        }
    }
}
