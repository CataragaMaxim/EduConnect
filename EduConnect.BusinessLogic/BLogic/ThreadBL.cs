using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.BusinessLogic.Core;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;

namespace EduConnect.BusinessLogic.BLogic
{
    public class ThreadBL : ThreadApi, IThread
    {
        public AddThreadResp AddThread(AddThreadDTO local)
        {
            return AddThreadAction(local);
        }

        public IEnumerable<UDbThreads> GetAllThreads()
        {
            return GetAllThreadsAction();
        }

        public UDbThreads GetThreadById(int id)
        {
            return GetThreadByIdAction(id);
        }
  
        public void AddComment(int threadId, string author, string content)
        {
            AddCommentAction(threadId, author, content);
        }

        public List<UDbComment> GetCommentsByThreadId(int threadId)
        {
             return GetCommentsByThreadIdAction(threadId);
        }

        public void UpdateThread(UDbThreads thread)
          {
               UpdateThreadAction(thread);
          }

          public void DeleteThread(int id)
          {
               DeleteThreadAction(id);
          }

     }
}
