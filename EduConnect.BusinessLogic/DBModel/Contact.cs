using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduConnect.Domain.Entities.User
{
    [Table("Contacts")]
	public class Contact
	{
        [Key] 
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100), Required]
        public string Email { get; set; }
        [StringLength(1000), Required]
        public string Subiect { get; set; }
        [StringLength(1000), Required]
        public string Message { get; set; }



    }
}