using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduConnect.Models.Auth
{
	public class UserAuthData
	{
          [Required(ErrorMessage = "Numele este obligatoriu")]
          public string Username { get; set; }
          [Required(ErrorMessage = "Parola este obligatorie")]
          public string Password { get; set; }
     }
}