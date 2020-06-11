using System.Threading.Tasks;
using IdentityDemo.Controller;
using IdentityDemo.Models.Identity;
using Microsoft.AspNetCore.Identity;
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
            var mockUserStore = new Mock<IUserLockoutStore<BlogUser>>();
            var userManager = new UserManager<BlogUser>(mockUserStore.Object, null, null, null, null, null, null, null, null);
            // var mockUserManager = Mock.Of<UserManager<BlogUser>>();

            var login = new LoginData { Username = "Keith!" };

            var controller = new UsersController(userManager, null);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact(Skip = "Stuck!")]
        public async Task Login_fails_with_invalid_password()
        {
            // Arrange
            // Stuck! Need an IUserStore<> that implements IUserPasswordStore<>, too!
            var mockUserStore = new Mock<IUserLockoutStore<BlogUser>>();
            var userManager = new UserManager<BlogUser>(mockUserStore.Object, null, null, null, null, null, null, null, null);
            // var mockUserManager = Mock.Of<UserManager<BlogUser>>();

            var login = new LoginData { Username = "Keith!" };

            mockUserStore.Setup(s => s.FindByNameAsync(login.Username, default))
                .ReturnsAsync(new BlogUser { UserName = login.Username });


            var controller = new UsersController(userManager, null);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
