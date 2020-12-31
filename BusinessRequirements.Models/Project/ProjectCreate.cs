using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.Project
{
    public class ProjectCreate
    {
        [Required]
        public int Ticket { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(40, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "There are too many characters in this field.")]
        public string Area { get; set; }
        [Required]
        public decimal Budget { get; set; }
    }
}
