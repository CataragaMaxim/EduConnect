using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduConnect.Models
{
     public class UserProfileVM
     {
          public string Username { get; set; }
          public string Role { get; set; }
          public string Email { get; set; }
          public string ProfileImageUrl { get; set; }  // Optional, default avatar
     }
}