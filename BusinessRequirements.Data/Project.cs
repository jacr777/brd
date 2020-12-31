using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int Ticket { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string ProjectName { get; set; }
        [Required]
        public string Area { get; set; }
        public decimal Budget { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
