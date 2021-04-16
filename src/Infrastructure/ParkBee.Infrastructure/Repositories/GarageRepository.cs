using Microsoft.EntityFrameworkCore;
using ParkBee.Application.Interface;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private readonly IApplicationContext _context;

        public GarageRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task InsertGarageAsync(Garage garage)
        {
            await _context.Set<Garage>().AddAsync(garage);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<GarageDetail> GetGarageByIdAsync(Guid userId)
        {
            var garage = await _context.Set<Garage>().Include(x => x.GarageDetail).Include(p => p.GarageDetail.Doors).FirstOrDefaultAsync(x => x.CustomerId == userId);
            return garage.GarageDetail;
        }
        public async Task<bool> UpdateDoorStatusAsync(Door door)
        {
            return 1 == await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task AddHistoricalDoorStatusLogAsync(DoorsStatusHistory doorsStatusHistory)
        {
            await _context.Set<DoorsStatusHistory>().AddAsync(doorsStatusHistory);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Door> GetDoorByIPAddressAsync(string ipAddress)
        {
           return await _context.Set<Door>().FirstOrDefaultAsync(x => x.IPAddress == ipAddress);
        }
    }
}
