using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Models.Project
{
    public class ProjectListItem
    {
        public int ProjectId { get; set; }
        public int Ticket { get; set; }
        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        public string Area { get; set; }  
        public decimal Budget { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
