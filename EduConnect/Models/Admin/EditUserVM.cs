using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduConnect.Models.Admin
{
     public class EditUserVM
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }

          [Display(Name = "Level")]
          public int Level { get; set; }
     }
}