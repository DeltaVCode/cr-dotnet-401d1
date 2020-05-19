using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
