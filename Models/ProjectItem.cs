using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Models
{
    public class ProjectItem
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Induction Date")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Induction Date")]
        public DateTime EndTime { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
