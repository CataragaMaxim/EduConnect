﻿using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Interfaces
{
     public interface IAdmin
     {
          IEnumerable<UDbTable> GetAllUsers();
          UDbTable GetUserById(int id);
          bool UpdateUser(UDbTable user);
          bool DeleteUser(int id);
          IEnumerable<UDbThreads> GetAllThreads();
            UDbThreads GetThreadById(int id);
            bool UpdateThread(UDbThreads thread);
            bool DeleteThread(int id);

    }
}
