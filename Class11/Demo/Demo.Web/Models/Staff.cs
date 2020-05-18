using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Web.Models
{
    public class Staff
    {
        public string Name { get; set; }
        public Role Role { get; set; }

        public static List<Staff> GetStaff()
        {
            //return new List<Staff>
            //{
            //    new Staff { Name = "Keith", Role = Role.Instructor },
            //    new Staff { Name = "Craig", Role = Role.Instructor },
            //    new Staff { Name = "Aaron", Role = Role.Admin },
            //};
            string[] staff = File.ReadAllLines("App_Data/Staff.csv");

            return staff
                .Skip(1) // skip the header
                .Select(staffLine => staffLine.Split(",")) // split line into cells
                .Select(staffCells => new Staff // make new Staff from cells
                {
                    Name = staffCells[0],
                    Role = (Role)Enum.Parse(typeof(Role), staffCells[1]),
                })
                .ToList();
        }
    }

    public enum Role
    {
        Instructor,
        Admin,
    }
}
