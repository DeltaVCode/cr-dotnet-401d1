using System.Collections.Generic;

namespace Demo.Web.Models
{
    public class Staff
    {
        public string Name { get; set; }
        public Role Role { get; set; }

        public static List<Staff> GetStaff()
        {
            return new List<Staff>
            {
                new Staff { Name = "Keith", Role = Role.Instructor },
                new Staff { Name = "Craig", Role = Role.Instructor },
                new Staff { Name = "Aaron", Role = Role.Admin },
            };
        }
    }

    public enum Role
    {
        Instructor,
        Admin,
    }
}
