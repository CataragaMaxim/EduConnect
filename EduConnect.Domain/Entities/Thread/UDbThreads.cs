using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Categ;

namespace EduConnect.Domain.Entities.Thread
{
    public class UDbThreads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "The title cannot be longer than 128 characters.")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Description")]
        [StringLength(2048, MinimumLength = 1, ErrorMessage = "The descripton cannot be longer than 2048 characters.")]
        public string Description { get; set; }
    }
}