using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduConnect.Models
{
     public class UserSettingsVM
     {
          public string Username { get; set; }
          public string Email { get; set; }

          // Schimbare parolă
          public string CurrentPassword { get; set; }
          public string NewPassword { get; set; }

          public string Message { get; set; }
     }
}
