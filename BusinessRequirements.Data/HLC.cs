using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Data
{
    public class HLC
    {
        [Key]
        public int HLCId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "HLC #")]
        public int HLCNumber { get; set; }
        [Required]
        [Display(Name = "HLC Description")]
        [MaxLength(600, ErrorMessage = "There are too many characters in this field.")]
        public string HLCDescription { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
