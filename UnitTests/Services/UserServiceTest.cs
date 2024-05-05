using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void IsUserEmailComfirmedSchouldReturnTrueWhenInputIsTrue()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();
            user.UserName = "Testowy";
            user.EmailConfirmed = true;

            UserService service = new UserService();

            //Act

            bool isEmailConfirmed = service.IsUserEmailConfirmed(user);

            //Assert

            Assert.True(isEmailConfirmed);
        }

        [Fact]
        public void IsUserEmailComfirmedSchouldReturnFalseWhenInputIsFalse()
        {
            //Arrange
            ApplicationUser user = new ApplicationUser();
            user.UserName = "Testowy";
            user.EmailConfirmed = false;

            UserService service = new UserService();

            //Act

            bool isEmailConfirmed = service.IsUserEmailConfirmed(user);

            //Assert

            Assert.False(isEmailConfirmed);
        }
    }
}
