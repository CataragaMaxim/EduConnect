﻿using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.BusinessLogic.Interfaces
{
     public interface IAuth
     {
          string UserAuthLogic(UserLoginDTO data);
     }
}
