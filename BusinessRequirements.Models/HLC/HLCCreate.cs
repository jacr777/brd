using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.HLC
{
    public class HLCCreate
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        [Display(Name = "HLC Number")]
        public int HLCNumber { get; set; }
        [Required]
        [Display(Name = "HLC Description")]
        [MaxLength(8000)]
        public string HLCDescription { get; set; }
    }
}
