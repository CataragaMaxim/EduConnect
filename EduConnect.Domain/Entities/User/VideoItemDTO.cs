using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect.Domain.Entities.User
{
     public class VideoDTO
     {
          public string Title { get; set; }
          public string Description { get; set; } // nou
          public string VideoUrl { get; set; }
          public int Order { get; set; }
     }

}
