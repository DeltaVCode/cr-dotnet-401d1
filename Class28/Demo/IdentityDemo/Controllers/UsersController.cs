using System.Threading.Tasks;
using IdentityDemo.Models.Identity;
using IdentityDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            // This might be used if you want to save an Auth cookie
            // var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

            var user = await userService.FindByNameAsync(login.Username);
            if (user != null)
            {
                var result = await userService.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new UserWithToken
                    {
                        UserId = user.Id,
                        Token = userService.CreateToken(user),
                    });
                }

                await userService.AccessFailedAsync(user);
            }
            return Unauthorized();
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

            var result = await userService.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                // TODO: is there a better object type to return here?
                return BadRequest(new
                {
                    message = "Registration failed",
                    errors = result.Errors,
                });
            }

            return Ok(new UserWithToken
            {
                UserId = user.Id,
                Token = userService.CreateToken(user),
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await userService.FindByIdAsync(userId);
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
            var user = await userService.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.BirthDate = data.BirthDate;

            await userService.UpdateAsync(user);

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