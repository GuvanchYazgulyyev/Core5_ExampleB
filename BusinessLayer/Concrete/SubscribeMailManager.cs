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
    public class SubscribeMailManager: ISubscribeMailService
    {
        ISubscribeMailDal _subscribeMail;
        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMail = subscribeMailDal;
        }

        public void AddSubscribeMail(SubscribeMail subscribeMail)
        {
            _subscribeMail.Insert(subscribeMail);
        }
    }
}
