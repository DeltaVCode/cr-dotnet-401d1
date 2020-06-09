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

            var admin = new IdentityRole
            {
                Id = "admin",
                Name = "Administrator",
                ConcurrencyStamp = "17722115-21fd-4451-8db4-e99f5c602421",
            };
            var moderator = new IdentityRole
            {
                Id = "moderator",
                Name = "Moderator",
                ConcurrencyStamp = "79b16ad0-71fc-4d45-851a-c8c0544adf1d",
            };
            builder.Entity<IdentityRole>()
                .HasData(admin, moderator);

            // This technically works, but generates a new SecurityStamp every migration
            // and resets our password!

            //var h = new PasswordHasher<BlogUser>();
            //var user = new BlogUser
            //{
            //    Id = "dbfcc1a5-fe40-4539-9e3c-ae5d75c09e19",
            //    UserName = "keith",
            //    FirstName = "Keith",
            //    LastName = "Dahlby",
            //    ConcurrencyStamp = "8d4b7189-803f-4c62-a5e9-bbbce2f08c36",
            //};
            //user.PasswordHash = h.HashPassword(user, "p@ssw0rd");
            //builder.Entity<BlogUser>()
            //    .HasData(user);

            //builder.Entity<IdentityUserRole<string>>()
            //    .HasData(new IdentityUserRole<string> { RoleId = "admin", UserId = user.Id });
        }
    }
}
