using EduConnect.BusinessLogic.DBModel;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User;
using EduConnect.Domain.Entities.User.Reg;
using EduConnect.Domain.User.Auth;
using EduConnect.Domain.User.Reg;
using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Core
{
    public class UserApi
    {

          public UserApi() { }
          public bool IsSessionValidAction(string key)
          {
               return true;
          }
          public int GetUserIdBySessionKeyAction(string sessionKey)
          {
               return 1;
          }
          public UserUpdateResp UpdateUserSettingsAction(string currentUsername, string newUsername, string newEmail)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Username == currentUsername);
                    if (user == null)
                    {
                         return new UserUpdateResp
                         {
                              Success = false,
                              Message = "Utilizatorul curent nu a fost găsit."
                         };
                    }

                    if (user.Username == newUsername && user.Email == newEmail)
                    {
                         return new UserUpdateResp
                         {
                              Success = false,
                              Message = "Datele sunt identice cu cele existente. Nicio modificare necesară."
                         };
                    }

                    if (user.Username != newUsername &&
                        db.Users.Any(u => u.Username == newUsername && u.Id != user.Id))
                    {
                         return new UserUpdateResp
                         {
                              Success = false,
                              Message = "Noul nume este deja folosit."
                         };
                    }

                    if (user.Email != newEmail &&
                        db.Users.Any(u => u.Email == newEmail && u.Id != user.Id))
                    {
                         return new UserUpdateResp
                         {
                              Success = false,
                              Message = "Noul email este deja folosit."
                         };
                    }

                    user.Username = newUsername;
                    user.Email = newEmail;
                    db.SaveChanges();

                    return new UserUpdateResp
                    {
                         Success = true,
                         Message = "Datele au fost actualizate cu succes."
                    };
               }
          }
          public string AuthenticateUserAction(UserAuthAction auth)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u =>
                        u.Username == auth.Username &&
                        u.Password == auth.Password
                    );

                    if (user != null)
                    {
                         user.LastLogin = DateTime.Now;
                         db.SaveChanges();

                         return Guid.NewGuid().ToString();
                    }
               }

               return null;
          }
          public UDbTable GetUserByUsernameAction(string username)
          {
               using (var db = new UserContext())
               {
                    return db.Users.FirstOrDefault(u => u.Username == username);
               }
          }
          internal UserRegDataResp SetRegisterUserAction(RegDataActionDTO local)
          {

               UDbTable user;

               using (var db = new UserContext())
               {
                    user = db.Users.FirstOrDefault(u => u.Username == local.Username);
               }

               if (user != null)
               {
                    return new UserRegDataResp()
                    {
                         Status = false,
                         Error = "This Username already exists"
                    };
               }

               var u_data = new UDbTable()
               {
                    Username = local.Username,
                    Password = local.Password,
                    Email = local.Email,
                    LastLogin = DateTime.Now,
                    Level = URole.User,
               };

               using (var db = new UserContext())
               {
                    db.Users.Add(u_data);
                    db.SaveChanges();
               }




                return new UserRegDataResp() { Status = true };
          }
    }
}
