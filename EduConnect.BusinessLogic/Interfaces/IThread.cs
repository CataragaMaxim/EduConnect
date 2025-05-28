using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Thread;

namespace EduConnect.BusinessLogic.Interfaces
{
    public interface IThread
    {
        UDbThreads GetThreadById(int Id);
        UDbThreads GetAllThreads();
    }
}
