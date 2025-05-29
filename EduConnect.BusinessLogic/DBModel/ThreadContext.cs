using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Thread;

namespace EduConnect.BusinessLogic.DBModel
{
    class ThreadContext : DbContext
    {
        public DbSet<Thread> Threads { get; set; }
    }
}
