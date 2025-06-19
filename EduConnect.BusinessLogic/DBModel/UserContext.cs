using EduConnect.Domain.Entities.Courses;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          public virtual DbSet<UDbComment> Comments { get; set; }
          public DbSet<UDbCourse> Courses { get; set; }
          public DbSet<VideoItem> VideoItems { get; set; }


     }
}
