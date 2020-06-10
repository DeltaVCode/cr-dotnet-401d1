using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityDemo.Services
{
    public class UserManagerWrapper : IUserManager
    {
        private readonly UserManager<BlogUser> userManager;
        private readonly IConfiguration configuration;

        public UserManagerWrapper(UserManager<BlogUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
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

        public string CreateToken(BlogUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddSeconds(10),
                claims: tokenClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
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
        string CreateToken(BlogUser user);
    }
}
