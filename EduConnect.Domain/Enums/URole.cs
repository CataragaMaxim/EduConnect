using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.Domain.Enums
{
    public enum URole
    {
        Guest = 0,
        User = 1,
        Moderator = 101,
        Admin = 1000,
        AdminMax = 1001,
        AdminNic = 1002,
        AdminDor = 1003
     }
}