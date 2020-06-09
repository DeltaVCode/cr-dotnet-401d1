using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<BlogUser> userManager;

        public UsersController(UserManager<BlogUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            // This might be used if you want to save an Auth cookie
            // var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

            var user = await userManager.FindByNameAsync(login.Username);
            if (user == null)
                return Unauthorized();

            var result = await userManager.CheckPasswordAsync(user, login.Password);
            if (!result)
                return Unauthorized();

            return Ok(new
            {
                UserId = user.Id,
            });
        }

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

            return Ok(new
            {
                UserId = user.Id,
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
    }
}