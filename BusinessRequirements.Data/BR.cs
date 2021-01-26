using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Data
{
    public class BR
    {
        [Key]
        public int BRId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "BR #")]
        public int BRNumber { get; set; }
        [Required]
        [Display(Name = "Business Requirement")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string BusinessRequirement { get; set; }

        [ForeignKey(nameof(HLC))]
        public int HLCId { get; set; }
        public virtual HLC HLC { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }


        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
