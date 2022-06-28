using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IAllMessageService: IGenericService<AllMessage>
    {
        List<AllMessage> TGetInboxByWriter(int id);
        List<AllMessage> GetUserMessageName(int id);
    }
}
