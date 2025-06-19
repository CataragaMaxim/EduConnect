using EduConnect.BusinessLogic.BLogic;
using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EduConnect.BusinessLogic
{
    public class BussinesLogic
    {
          public ISession GetSessionBL(HttpSessionStateBase session, HttpRequestBase request, HttpResponseBase response)
          {
               return new SessionBL(session, request, response);
          }

          public IAdmin GetAdminBL()
          {
               return new AdminBL();
          }

          public IUser GetUserBL()
          {
               return new UserBL();
          }

            public IThread GetThreadBL()
            {
                return new ThreadBL();
            }

          public ICourse GetCourseBL()
          {
               return new CourseBL();
          }

     }
}
