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
    public class AllMessageManager:IAllMessageService
    {
        AllMessageDal _messageDal;

        public AllMessageManager(AllMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        // Alıcının Mesajını Listele
        public List<AllMessage> GetUserMessageName(int id)
        {
            return _messageDal.GetUserMessageName(id);
        }

        public void Passive(AllMessage t)
        {
            throw new NotImplementedException();
        }

        public void TAdd(AllMessage t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AllMessage t)
        {
            throw new NotImplementedException();
        }

        public AllMessage TGetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<AllMessage> TGetInboxByWriter(int id)
        {
            return _messageDal.GetListAll(k => k.ReceiverId == id);
        }

        public List<AllMessage> TGetList()
        {
            return _messageDal.GetListAll();
        }

        public void TUpdate(AllMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
