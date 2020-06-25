using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoDbContext : IdentityDbContext<ApplicationUser>
    {
        public TodoDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
        }

        public DbSet<Todo> Todo { get; set; }

        private int nextRoleClaimId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLowerInvariant(),
                Name = roleName,
                NormalizedName = roleName.ToUpperInvariant(),
                ConcurrencyStamp = roleName,
            };

            modelBuilder.Entity<IdentityRole>()
                .HasData(role);

            var roleClaims = permissions
                .Select(p =>
                    new IdentityRoleClaim<string>
                    {
                        Id = nextRoleClaimId++,
                        RoleId = role.Id,
                        ClaimType = "permissions",
                        ClaimValue = p
                    })
                .ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .HasData(roleClaims);
        }
    }
}
