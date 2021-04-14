using ParkBee.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.UnitTests.DomainTests
{
    public class UserTest
    {
        private User user;
        public UserTest()
        {
            user = User.CreateCustomer(FullName.CreateFullName("John", null, "Doe"),
                UserCredentials.CreateUserCredentials("Johny", "Pa55w0rd"), Role.CreateRole("Admin"));
        }
        [Fact]
        public void Should_Have_Create_User()
        {
            Assert.NotNull(user);
        }
        [Fact]
        public void Should_Have_Update_FullName()
        {           
            user.UpdateFullName(FullName.CreateFullName("Jane", "Taylor", "Doe"));
            Assert.Equal("Jane", user.FullName.FirstName);
            Assert.Equal("Taylor", user.FullName.MiddleName);
            Assert.Equal("Doe", user.FullName.LastName);
        }
        [Fact]
        public void Should_Have_Update_User_Role()
        {
            user.UpdateUserRole(Role.CreateRole("User"));
            Assert.Equal("User", user.Role.Roles);
        }

    }
}
