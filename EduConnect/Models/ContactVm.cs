﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduConnect.Models
{
        public class ContactVm
        {
            [Required]
            public string Name { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Subject { get; set; }

            [Required]
            public string Message { get; set; }
        }

    }