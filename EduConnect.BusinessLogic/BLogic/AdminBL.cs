using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.BLogic
{
     internal class AdminBL : AdminApi, IAdmin
     {
          public IEnumerable<UDbTable> GetAllUsers()
          {
               return GetAllUsersAction();
          }
          public UDbTable GetUserById(int id)
          {
               return GetUserByIdAction(id);
          }
          public bool UpdateUser(UDbTable user)
          {
               return UpdateUserAction(user);
          }
          public bool DeleteUser(int id)
          {
               return DeleteUserAction(id);
          }
        public IEnumerable<UDbThreads> GetAllThreads()
        {
            return GetAllThreadsAction();
        }
        public UDbThreads GetThreadById(int id)
        {
            return GetThreadByIdAction(id);
        }

        public bool UpdateThread(UDbThreads thread)
        {
            return UpdateThreadAction(thread);
        }

        public bool DeleteThread(int id)
        {
            return DeleteThreadAction(id);
        }

    }
}
