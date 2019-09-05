using FilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ManagementContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
            new Member{MemberName="Carson Alexander",InductionDate=DateTime.Parse("2015-09-01"),Age=26},
            new Member{MemberName="Meredith Alonso",InductionDate=DateTime.Parse("2012-09-01"),Age=27},
            new Member{MemberName="Arturo Anand",InductionDate=DateTime.Parse("2013-09-01"),Age=25},
            new Member{MemberName="Gytis Barzdukas",InductionDate=DateTime.Parse("2018-09-01"),Age=28},
            new Member{MemberName="Yan Li",InductionDate=DateTime.Parse("2014-09-01"),Age=32},
            new Member{MemberName="Peggy Justice",InductionDate=DateTime.Parse("2017-09-01"),Age=38},
            new Member{MemberName="Laura Norman",InductionDate=DateTime.Parse("2016-09-01"),Age=30},
            new Member{MemberName="Nino Olivetto",InductionDate=DateTime.Parse("2018-09-01"),Age=24}
            };
            foreach (Member s in members)
            {
                context.Members.Add(s);
            }
            context.SaveChanges();

            var projects = new ProjectItem[]
            {
            new ProjectItem{ProjectName="WuXi Project",StartTime=DateTime.Parse("2018-09-01"),EndTime=DateTime.Parse("2020-09-01")},
            new ProjectItem{ProjectName="NanJing Project",StartTime=DateTime.Parse("2016-09-01"),EndTime=DateTime.Parse("2019-09-01")},
            new ProjectItem{ProjectName="ShangHai Project",StartTime=DateTime.Parse("2016-09-01"),EndTime=DateTime.Parse("2019-09-01")},
            };
            foreach (ProjectItem p in projects)
            {
                context.ProjectItems.Add(p);
            }
            context.SaveChanges();

            var projectmembers = new ProjectMember[]
            {
            new ProjectMember{MemberID=1,ProjectID=1,Status="Work"},
            new ProjectMember{MemberID=1,ProjectID=2,Status="Work"},
            new ProjectMember{MemberID=1,ProjectID=3,Status="Work"},
            new ProjectMember{MemberID=2,ProjectID=1,Status="Work"},
            new ProjectMember{MemberID=2,ProjectID=2,Status="Work"},
            new ProjectMember{MemberID=2,ProjectID=3,Status="Work"},
            new ProjectMember{MemberID=3,ProjectID=3,Status="Work"},
            new ProjectMember{MemberID=4,ProjectID=1,Status="Departure"},
            new ProjectMember{MemberID=4,ProjectID=2,Status="Departure"},
            new ProjectMember{MemberID=5,ProjectID=2,Status="Work"},
            new ProjectMember{MemberID=6,ProjectID=3,Status="Departure"},
            new ProjectMember{MemberID=7,ProjectID=1,Status="Departure"},
            };
            foreach (ProjectMember e in projectmembers)
            {
                context.ProjectMembers.Add(e);
            }
            context.SaveChanges();
        }
    }
}
