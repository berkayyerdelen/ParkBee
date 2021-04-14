using ParkBee.Core.Domain.Users.Commands;
using ParkBee.Core.Domain.Users.Queries;
using ParkBee.Domain.UserAggregate;
using ParkBee.Infrastructure;
using ParkBee.Infrastructure.Repositories;
using ParkBee.IntegrationTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.IntegrationTests.Domains
{
    [Collection("QueryCollection")]
    public class UserHandlersTest
    {
        private readonly ApplicationContext _context;
        private readonly UserRepository userRepository;
        public UserHandlersTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            userRepository = new UserRepository(_context);
        }
        [Fact]
        public async Task Should_Have_Return_User_List()
        {
            var handler = new GetUsersQueryHandler(userRepository);
            var result = await handler.Handle(new GetUsersQuery(), CancellationToken.None);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task Should_Have_Create_User()
        {
            var command = new CreateUserCommand()
            {
                FirstName = "Oguz",
                MiddleName = "Berkay",
                LastName = "Yerdelen",
                Password = "5ecret",
                UserName = "Dualist"
            };
            var handler = new CreateUserCommandHandler(userRepository);          
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal(3, _context.Set<User>().Count());           
        }
    }
}
