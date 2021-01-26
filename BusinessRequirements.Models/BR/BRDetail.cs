using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.BR
{
    public class BRDetail
    {
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [Display(Name = "HLC Id")]
        public int HLCId { get; set; }
        public int HLCNumber { get; set; }

        public int BRId { get; set; }
        [Display(Name = "BR #")]
        public int BRNumber { get; set; }
        [Display(Name = "Business Requirement")]
        public string BusinessRequirement { get; set; }
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified On")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
