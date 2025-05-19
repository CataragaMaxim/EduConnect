using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User;
using EduConnect.Domain.Entities.User.Reg;
using EduConnect.Domain.User.Auth;
using EduConnect.Domain.User.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.BLogic
{
    public class UserBL : UserApi, IUser
    {
          public string AuthenticateUser(UserAuthAction auth)
          {
               return AuthenticateUserAction(auth);
          }
          public UDbTable GetUserByUsername(string username)
          {
               return GetUserByUsernameAction(username);
          }
          //public int GetUserIdBySessionKey(string sessionKey)
          //{
          //     return GetUserIdBySessionKeyAction(sessionKey);
          //}

          //public bool IsSessionValid(string key)
          //{
          //     return IsSessionValidAction(key);
          //}
          public UserRegDataResp RegisterUserAction(RegDataActionDTO local)
          {
               return SetRegisterUserAction(local);
          }
     }
}
