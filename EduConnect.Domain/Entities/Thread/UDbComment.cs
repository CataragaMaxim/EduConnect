using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.Domain.Entities.Thread
{
     public class UDbComment
     {
          [Key]
          public int Id { get; set; }

          [Required]
          public int ThreadId { get; set; }

          [Required]
          public string Author { get; set; }

          [Required]
          [StringLength(1024)]
          public string Content { get; set; }

          public DateTime CreatedAt { get; set; } = DateTime.Now;

          [ForeignKey("ThreadId")]
          public UDbThreads Thread { get; set; }
     }

}
