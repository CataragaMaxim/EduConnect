using EduConnect.BusinessLogic.BLogic;
using EduConnect.BusinessLogic.BLStruct;
using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic
{
    public class BussinesLogic
    {
          public IAuth GetAuthBL()
          {
               return new AuthBL();
          }
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

          public IUser GetUserBL()
          {
               return new UserBL();
          }
     }
}
