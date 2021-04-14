using ParkBee.Core.Domain.Garages.Commands;
using ParkBee.Core.Domain.Garages.Queries;
using ParkBee.Domain.GarageAggregate;
using ParkBee.Infrastructure;
using ParkBee.Infrastructure.Repositories;
using ParkBee.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParkBee.IntegrationTests.Domains
{
    [Collection("QueryCollection")]
    public class GarageHandlersTests
    {
        private readonly ApplicationContext _context;
        private readonly GarageRepository garageRepository;
        public GarageHandlersTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            garageRepository = new GarageRepository(_context);
        }
        [Fact]
        public async Task Should_Have_Return_Garage_Detail_By_Id()
        {
            var id = new Guid("9c90483c-3a44-47b2-a44c-ea62bf7f1558");
            var request = new GetGaragesQuery(id);
            var handler = new GetGaragesQueryHandler(garageRepository);
            var result =await handler.Handle(request, CancellationToken.None);
            Assert.Equal("Hank's Place", result.GarageName);
        }
        [Fact]
        public async Task Should_Have_Create_Garage()
        {
            var command = new CreateGarageCommand() { CountryCode ="nl",CustomerId = Guid.NewGuid(),GarageName="Garage"};
            var handler = new CreateGarageCommandHandler(garageRepository);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal(3, _context.Set<Garage>().Count());
        }
    }
}
