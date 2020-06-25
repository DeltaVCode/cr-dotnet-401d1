using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApi.Models;
using TodoApi.Models.Api;

namespace TodoApi.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<UserWithToken> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (!await userManager.CheckPasswordAsync(user, password))
                return null;

            return await GetUserWithToken(user);
        }

        public async Task<User> GetUser(ClaimsPrincipal user)
        {
            return await userManager.GetUserAsync(user);
        }

        public async Task<UserWithToken> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, data.Roles);
                return await GetUserWithToken(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserWithToken> GetUserWithToken(ApplicationUser user)
        {
            return new UserWithToken
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, TimeSpan.FromMinutes(30))
            };
        }
    }
}
