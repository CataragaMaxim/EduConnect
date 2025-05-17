using EduConnect.Domain.Entities.User.Reg;
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
          UserRegDataResp RegisterUserAction(RegDataActionDTO local);
     }
}
