using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduConnect.Models
{
        public class ContactVm
        {
            [Required, StringLength(80)]
            public string Name { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required, StringLength(120)]
            public string Subject { get; set; }

            [Required, StringLength(1000)]
            public string Message { get; set; }
        }

    }