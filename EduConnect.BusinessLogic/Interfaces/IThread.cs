using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;

namespace EduConnect.BusinessLogic.Interfaces
{
    public interface IThread
    {

        UDbThreads GetThreadById(int id);
        IEnumerable<UDbThreads> GetAllThreads();
        AddThreadResp AddThread(AddThreadDTO local);
    }
}
