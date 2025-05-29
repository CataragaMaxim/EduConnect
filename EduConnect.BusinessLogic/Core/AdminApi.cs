using EduConnect.BusinessLogic.DBModel;
using EduConnect.Domain.Entities.User;
using EduConnect.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Core
{
    class AdminApi
    {
          protected IEnumerable<UDbTable> GetAllUsersAction()
          {
               using (var db = new UserContext())
               {
                    return db.Users.ToList();
               }
          }

          protected UDbTable GetUserByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.Users.FirstOrDefault(u => u.Id == id);
               }
          }



          protected bool UpdateUserAction(UDbTable updatedUser)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
                    if (user == null)
                         return false;

                    user.Username = updatedUser.Username;
                    user.Email = updatedUser.Email;
                    user.Level = updatedUser.Level;

                    if (!string.IsNullOrWhiteSpace(updatedUser.Password))
                    {
                         user.Password = PasswordHelper.HashGen(updatedUser.Password);
                    }

                    db.SaveChanges();
                    return true;
               }
          }


          protected bool DeleteUserAction(int id)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user == null)
                         return false;

                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
               }
          }
     }

     //protected IEnumerable<Thread> GetAllThreadsAction()
     //{
     //     using (var db = new ForumContext())
     //     {
     //          return db.Threads.ToList();
     //     }
     //}
}
