using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Technology> Technologies { get; set; }
    }
}
