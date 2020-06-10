using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Services
{
    public interface IUserService
    {
        Task<BlogUser> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(BlogUser user, string password);
        Task AccessFailedAsync(BlogUser user);
        Task<IdentityResult> CreateAsync(BlogUser user, string password);
        Task<BlogUser> FindByIdAsync(string userId);
        Task<IdentityResult> UpdateAsync(BlogUser user);
        string CreateToken(BlogUser user);
    }
}
