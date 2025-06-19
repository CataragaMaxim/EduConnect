using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnect.Domain.Entities.Courses
{
     public class VideoItem
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [ForeignKey("Course")]
          public int CourseId { get; set; }

          [Required, StringLength(128)]
          public string Title { get; set; }

          [Required]
          public string VideoUrl { get; set; }

          public int Order { get; set; }

          public virtual UDbCourse Course { get; set; }
     }
}
