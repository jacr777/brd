using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.HLC
{
    public class HLCEdit    {

        public int ProjectId { get; set; }
        public string Project { get; set; }
        public int HLCId { get; set; }
        [Display(Name = "HLC #")]
        public int HLCNumber { get; set; }
        [Display(Name = "HLC Description")]
        public string HLCDescription { get; set; }
    }
}
