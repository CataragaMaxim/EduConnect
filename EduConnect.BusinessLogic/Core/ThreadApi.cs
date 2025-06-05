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
        }
    }
