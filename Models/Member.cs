using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string MemberName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Induction Date")]
        public DateTime InductionDate { get; set; }
        public int? Age { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
