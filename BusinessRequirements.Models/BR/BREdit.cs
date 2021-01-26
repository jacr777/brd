using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.BR
{
    public class BREdit
    {
        public int HLCId { get; set; }
        [Display(Name = "HLC #")]
        public int HLCNumber { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int BRId { get; set; }  
        [Display(Name = "BR #")]
        public int BRNumber { get; set; }
        [Display(Name = "Business Requirement")]
        public string BusinessRequirement { get; set; }
    }
}
