using System.ComponentModel.DataAnnotations;

namespace EduConnect.Web.Models
{
    public class UserLogin
    {
        public string Credential { get; set; }
        public string Password { get; set; }
    }
}