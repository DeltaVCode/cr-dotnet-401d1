using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Data
{
    public class UsersDbContext : IdentityDbContext<BlogUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
