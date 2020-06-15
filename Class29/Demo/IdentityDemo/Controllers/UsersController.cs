using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<BlogUser> userManager;
        private readonly SignInManager<BlogUser> signInManager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<BlogUser> userManager,
            SignInManager<BlogUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [Authorize]
        [HttpGet("Self")]
        public async Task<IActionResult> Self()
        {
            if (User.Identity is ClaimsIdentity identity)
            {
                var usernameClaim = identity.FindFirst("UserId");
                var userId = usernameClaim.Value;

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Unauthorized();
                }

                var roles = /* if current user is admin, then */
                    identity.Claims
                        .Where(c => c.Type == identity.RoleClaimType)
                        .Select(c => c.Value)
                        .ToList();

                // Or, go to the database (slower, but maybe more accurate)
                // var roles = await userManager.GetRolesAsync(user);

                return base.Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.BirthDate,

                    Roles = roles,
                });
            }

            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            // This might be used if you want to save an Auth cookie
            // var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

            var user = await userManager.FindByNameAsync(login.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new
                    {
                        UserId = user.Id,
                        Token = await CreateTokenAsync(user),
                    });
                }

                await userManager.AccessFailedAsync(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData register)
        {
            var user = new BlogUser
            {
                Email = register.Email,
                UserName = register.Email,

                FirstName = register.FirstName,
                LastName = register.LastName,
                BirthDate = register.BirthDate,
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                // TODO: is there a better object type to return here?
                return BadRequest(new
                {
                    message = "Registration failed",
                    errors = result.Errors,
                });
            }

            // If user is an admin OR there aren't any users
            // Allow register to include Roles
            if (User.IsInRole("Administrator") || !await userManager.Users.AnyAsync())
            {
                await userManager.AddToRolesAsync(user, register.Roles);
            }

            return Ok(new
            {
                UserId = user.Id,
                Token = await CreateTokenAsync(user),
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.BirthDate,
            });
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, UpdateUserData data)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.BirthDate = data.BirthDate;

            await userManager.UpdateAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.BirthDate,
            });
        }

        private async Task<string> CreateTokenAsync(BlogUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;
            identity.AddClaims(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            });

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}