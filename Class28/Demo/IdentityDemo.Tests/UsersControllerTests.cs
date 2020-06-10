using System;
using System.Threading.Tasks;
using IdentityDemo.Controller;
using IdentityDemo.Models.Identity;
using IdentityDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IdentityDemo.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task Login_fails_with_missing_user()
        {
            // Arrange
            var userService = new Mock<IUserService>();

            // throw if AccessFailedAsync() called without a user
            userService.Setup(m => m.AccessFailedAsync(null))
                .Throws(new ArgumentNullException());

            var login = new LoginData { Username = "Keith!" };

            var controller = new UsersController(userService.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Login_fails_with_invalid_password()
        {
            // Arrange
            var userService = new Mock<IUserService>();

            var login = new LoginData { Username = "Keith!" };

            userService.Setup(s => s.FindByNameAsync(login.Username))
                .ReturnsAsync(new BlogUser { UserName = login.Username });

            var controller = new UsersController(userService.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task Login_succeeds_with_valid_password()
        {
            // Arrange
            var userService = new Mock<IUserService>();

            var login = new LoginData { Username = "Keith!", Password = "!!!" };

            var user = new BlogUser { UserName = login.Username };
            userService.Setup(s => s.FindByNameAsync(login.Username))
                .ReturnsAsync(user);

            userService.Setup(s => s.CheckPasswordAsync(user, login.Password))
                .ReturnsAsync(true);

            userService.Setup(s => s.CreateToken(user))
                .Returns("test token!");

            var controller = new UsersController(userService.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var userWithToken = Assert.IsType<UserWithToken>(okResult.Value);
            Assert.Equal(user.Id, userWithToken.UserId);
            Assert.Equal("test token!", userWithToken.Token);
        }
    }
}
