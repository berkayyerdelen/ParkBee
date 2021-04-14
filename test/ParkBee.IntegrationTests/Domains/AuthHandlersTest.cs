using Microsoft.Extensions.Options;
using ParkBee.Core.Common.DTO;
using ParkBee.Core.Domain.Auth.Queries;
using ParkBee.Infrastructure;
using ParkBee.Infrastructure.Repositories;
using ParkBee.Infrastructure.Repositories.Security;
using ParkBee.IntegrationTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.IntegrationTests.Domains.Auth
{
    [Collection("QueryCollection")]
    public class AuthHandlersTest
    {
        private readonly ApplicationContext _context;
        private readonly UserRepository userRepository;
        private readonly AuthenticationService authenticationService;
        private readonly JwtOptions optionsInstance;
        private readonly IOptions<JwtOptions> options;
        public AuthHandlersTest(QueryTestFixture fixture)
        {
            optionsInstance = new JwtOptions() { Issuer = "parkbee.com", SecurityKey = "superUberDuperSecret" };
            options = Options.Create(optionsInstance);
            _context = fixture.Context;
            userRepository = new UserRepository(_context);
            authenticationService = new AuthenticationService(options);
        }
     
        [Fact]
        public async Task Should_Have_Return_Token()
        {
            var handler = new LoginRequestHandler(authenticationService, userRepository);
            var result = await handler.Handle(new LoginRequest() { UserName = "Johny", Password = "Pa55w0rd" }, CancellationToken.None);
            Assert.IsType<TokenResponseModel>(result);
            Assert.NotNull(result);
        }
    }
}
