using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduConnect.Models.Admin
{
     public class AdminProfileVM
     {
          public string Username { get; set; }
          public string Role { get; set; }
          public string Email { get; set; }
          public string ProfileImageUrl { get; set; }  // Opțional, default avatar
     }
}