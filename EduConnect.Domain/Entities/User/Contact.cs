using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduConnect.ViewModel
{
    
	public class Contact
	{

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Message { get; set; }
        
        public string Subiect { get; set; }
        

    }
}