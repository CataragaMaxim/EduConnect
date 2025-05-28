using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.BusinessLogic.Core;
using EduConnect.Domain.Entities.Thread;

namespace EduConnect.BusinessLogic.BLogic
{
    public class ThreadBL : ThreadApi, IThread
    {
        public UDbThreads GetAllThreads()
        {
            throw new NotImplementedException();
        }

        UDbThreads IThread.GetThreadById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
