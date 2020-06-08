using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Data
{
    public class UsersDbContext : IdentityDbContext<BlogUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole { Id = "admin", Name = "Administrator" };
            var moderator = new IdentityRole { Id = "moderator", Name = "Moderator" };
            builder.Entity<IdentityRole>()
                .HasData(admin, moderator);
        }
    }
}
