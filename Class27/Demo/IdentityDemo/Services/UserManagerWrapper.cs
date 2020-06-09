using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Services
{
    public class UserManagerWrapper : IUserManager
    {
        private readonly UserManager<BlogUser> userManager;

        public UserManagerWrapper(UserManager<BlogUser> userManager)
        {
            this.userManager = userManager;
        }

        public Task AccessFailedAsync(BlogUser user)
        {
            return userManager.AccessFailedAsync(user);
        }

        public Task<bool> CheckPasswordAsync(BlogUser user, string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }

        public Task<IdentityResult> CreateAsync(BlogUser user, string password)
        {
            return userManager.CreateAsync(user, password);
        }

        public Task<BlogUser> FindByIdAsync(string userId)
        {
            return userManager.FindByIdAsync(userId);
        }

        public Task<BlogUser> FindByNameAsync(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        public Task<IdentityResult> UpdateAsync(BlogUser user)
        {
            return userManager.UpdateAsync(user);
        }
    }

    public interface IUserManager
    {
        Task<BlogUser> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(BlogUser user, string password);
        Task AccessFailedAsync(BlogUser user);
        Task<IdentityResult> CreateAsync(BlogUser user, string password);
        Task<BlogUser> FindByIdAsync(string userId);
        Task<IdentityResult> UpdateAsync(BlogUser user);
    }
}
