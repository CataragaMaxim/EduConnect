using EduConnect.Domain.Entities.User;
using EduConnect.Domain.Entities.User.Reg;
using EduConnect.Domain.User.Auth;
using EduConnect.Domain.User.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Interfaces
{
     public interface IUser
     {
          string AuthenticateUser(UserAuthAction auth);
          UDbTable GetUserByUsername(string username);
          UserRegDataResp RegisterUserAction(RegDataActionDTO local);
          UserUpdateResp UpdateUserSettings(string currentUsername, string newUsername, string newEmail, string currentPassword, string newPassword);
     }
}
