using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;

namespace EduConnect.BusinessLogic.DBModel
{
    class UserContext : DbContext
     {
          public UserContext() :
               base("name=EduConnect")
          {
          }

          public virtual DbSet<UDbTable> Users { get; set; }
          public virtual DbSet<UDbThreads> Threads { get; set; }
    }
}
