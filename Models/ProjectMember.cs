using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Models
{
    public class ProjectMember
    {
        public int ProjectMemberID { get; set; }
        public int ProjectID { get; set; }
        public int MemberID { get; set; }
        [Required]
        public string Status { get; set; }
        public ProjectItem Project { get; set; }
        public Member Member { get; set; }
    }
}
