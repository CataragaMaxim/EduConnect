using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.Models.Reg
{
	public class UserRegData
	{
          [Required]
          [StringLength(30, MinimumLength = 5, ErrorMessage = "Numele nu este valid")]
          public string Username { get; set; }

          [Required]
          [StringLength(50, MinimumLength = 8, ErrorMessage = "Parola nu este valid")]
          public string Password { get; set; }

          [Required]
          [EmailAddress(ErrorMessage = "Email-ul nu este valid")]
          public string Email { get; set; }

     }
}