using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.BLStruct
{
     class AuthBL : UserApi, IAuth
     {
          public string UserAuthLogic(UserLoginDTO data)
          {
               return UserAuthLogicAction(data);
          }
     }
}