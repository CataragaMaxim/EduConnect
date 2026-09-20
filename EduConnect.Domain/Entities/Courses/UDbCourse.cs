using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnect.Domain.Entities.Courses
{
     public class UDbCourse
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required, StringLength(128)]
          public string Title { get; set; }

          [StringLength(2048)]
          public string Description { get; set; }

          [Required, StringLength(64)]
          public string Category { get; set; }

          // Ex: "public", "private", "restricted"
          [Required]
          public string AccessLevel { get; set; }

          // Lista de useri permisi (pentru access "restricted")
          public string AllowedUsers { get; set; }

          public string CreatedBy { get; set; }
          public DateTime CreatedAt { get; set; }

          // Navigational property for video list
          public virtual ICollection<VideoItem> VideoItems { get; set; }
     }
}
