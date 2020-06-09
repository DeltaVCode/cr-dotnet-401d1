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

            var h = new PasswordHasher<BlogUser>();
            var user = new BlogUser
            {
                Id = "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19",
                UserName = "keith",
                FirstName = "Keith",
                LastName = "Dahlby",
            };
            user.PasswordHash = h.HashPassword(user, "p@ssw0rd");
            builder.Entity<BlogUser>()
                .HasData(user);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string> { RoleId = "admin", UserId = user.Id });
        }
    }
}
