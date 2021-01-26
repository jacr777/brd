using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.BR
{
    public class BRCreate
    {
        [Required]
        public int HLCId { get; set; }
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "BR #")]
        public int BRNumber { get; set; }

        [Required]
        [Display(Name = "Business Requirement")]
        [MaxLength(2000)]
        public string BusinessRequirement { get; set; }
    }
}
