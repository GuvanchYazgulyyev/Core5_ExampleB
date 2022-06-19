using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Passive(Message t)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetInboxByWriter(string p)
        {
            return _messageDal.GetListAll(k=>k.Receiver==p);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetListAll();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
