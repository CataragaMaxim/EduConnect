using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.Domain.Entities.User
{
     public class AddCourseDTO
     {
          public int Id { get; set; }

          [Required]
          public string Title { get; set; }

          public string Description { get; set; }

          [Required]
          public string Category { get; set; }

          [Required]
          public string AccessLevel { get; set; } // Public, Private, Restricted

          public string AllowedUsers { get; set; } // ex: user1,user2

          public string CreatedBy { get; set; }

          public string VideoUrl { get; set; } // temporar, doar la creare

          public List<VideoDTO> Videos { get; set; } = new List<VideoDTO>();
     }
}
