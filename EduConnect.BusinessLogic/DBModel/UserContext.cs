using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.User;
using EduConnect.BusinessLogic.DBModel;


namespace EduConnect.BusinessLogic.DBModel
{
    public class UserContext : DbContext
     {
          public UserContext() : base("name=EduConnect")
          {
          }

          public virtual DbSet<UDbTable> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
