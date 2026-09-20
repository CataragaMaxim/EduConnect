    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EduConnect.BusinessLogic.DBModel;
    using EduConnect.Domain.Entities.Thread;
    using EduConnect.Domain.Entities.User;

    namespace EduConnect.BusinessLogic.Core
    {
        public class ThreadApi
        {
            public AddThreadResp AddThreadAction(AddThreadDTO local)
            {

               var u_data = new UDbThreads()
               {
                    Title = local.Title,
                    Author = local.Author,
                    Category = local.Category,
                    Description = local.Description
               };

               using (var db = new UserContext())
               {
                    db.Threads.Add(u_data);
                    db.SaveChanges();
               }



                return new AddThreadResp() { Status = true };
            }
            public UDbThreads GetThreadByIdAction(int id)
            {
                using (var db = new UserContext())
                {
                    return db.Threads.FirstOrDefault(u => u.Id == id);
                }
            }
            public IEnumerable<UDbThreads> GetAllThreadsAction()
            {
                using (var db = new UserContext())
                {
                    return db.Threads.ToList();
                }
            }

          public void AddCommentAction(int threadId, string author, string content)
          {
               using (var db = new UserContext())
               {
                    var comment = new UDbComment
                    {
                         ThreadId = threadId,
                         Author = author,
                         Content = content
                    };

                    db.Comments.Add(comment);
                    db.SaveChanges();
               }
          }

          public List<UDbComment> GetCommentsByThreadIdAction(int threadId)
          {
               using (var db = new UserContext())
               {
                    return db.Comments
                             .Where(c => c.ThreadId == threadId)
                             .OrderByDescending(c => c.CreatedAt)
                             .ToList();
               }
          }

          public void UpdateThreadAction(UDbThreads thread)
          {
               using (var db = new UserContext())
               {
                    var existing = db.Threads.FirstOrDefault(t => t.Id == thread.Id);
                    if (existing != null)
                    {
                         existing.Title = thread.Title;
                         existing.Description = thread.Description;
                         existing.Category = thread.Category;

                         db.SaveChanges();
                    }
               }
          }

          public void DeleteThreadAction(int id)
          {
               using (var db = new UserContext())
               {
                    var thread = db.Threads.FirstOrDefault(t => t.Id == id);
                    if (thread != null)
                    {
                         db.Threads.Remove(thread);
                         db.SaveChanges();
                    }
               }
          }

     }
}
