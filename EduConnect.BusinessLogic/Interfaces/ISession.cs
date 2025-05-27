using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Interfaces
{
     public interface ISession
     {
          void SetUserSession(string username, int userLevel, string token, string email);
          void ClearUserSession();
          string GetUserToken();
          string GetUserEmail();
          bool IsSessionValid(string key);
          int GetUserIdBySessionKey(string key);
     }
}
