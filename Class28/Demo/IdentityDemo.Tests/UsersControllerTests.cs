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

        [Fact]
        public async Task Update_missing_user_returns_404()
        {
            // Arrange
            var userService = new Mock<IUserService>();

            userService.Setup(s => s.UpdateAsync(null)).Throws(new ArgumentNullException());

            var controller = new UsersController(userService.Object);

            // Act
            var result = await controller.UpdateUser("whatever", new UpdateUserData());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData("Testy", null, null)]
        [InlineData(null, "Lasty", null)]
        [InlineData(null, null, "2000-01-01")]
        public async Task Update_real_user_does_update(string firstName, string lastName, string birthDate)
        {
            // Arrange
            var userService = new Mock<IUserService>();

            var user = new BlogUser
            {
                Id = "12",
                UserName = "Testy McTestface",
            };

            userService.Setup(s => s.FindByIdAsync(user.Id)).ReturnsAsync(user);

            var controller = new UsersController(userService.Object);

            var data = new UpdateUserData
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate == null ? (DateTime?)null : DateTime.Parse(birthDate),
            };

            // Act
            var result = await controller.UpdateUser(user.Id, data);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedUser = Assert.IsType<UserDTO>(okResult.Value);

            Assert.Equal(data.FirstName, savedUser.FirstName);
            Assert.Equal(data.LastName, savedUser.LastName);
            Assert.Equal(data.BirthDate, savedUser.BirthDate);

            userService.Verify(s => s.UpdateAsync(user));

            // TODO: prove that UpdateAsync() called with an *updated* user
            // This can pass if UpdateAsync() is called after Find and before properties are set
        }
    }
}
