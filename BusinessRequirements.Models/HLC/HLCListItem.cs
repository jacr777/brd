using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.HLC
{
    public class HLCListItem
    {
        public int ProjectId { get; set; } 
        public string Project  { get; set; }
        public int HLCId { get; set; }
        [Display(Name = "HLC #")]
        public int HLCNumber { get; set; }
        [Display(Name = "HLC Description")]
        public string HLCDescription { get; set; }
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified On")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
