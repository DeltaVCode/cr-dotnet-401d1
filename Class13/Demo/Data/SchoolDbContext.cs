using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Does nothing, so we don't need to keep this
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new
                {
                    enrollment.CourseId,
                    enrollment.StudentId,
                });

            modelBuilder.Entity<Technology>()
                .HasData(
                    new Technology { Id = 1, Name = ".NET" },
                    new Technology { Id = 2, Name = "Node.js" }
                );
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Technology> Technologies { get; set; }
    }
}
