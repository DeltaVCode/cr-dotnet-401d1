namespace Demo.Web.Models
{
    public class Staff
    {
        public string Name { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Instructor,
        Admin,
    }
}
