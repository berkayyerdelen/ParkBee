using System;
using System.Threading.Tasks;

namespace ParkBee.Domain.GarageAggregate
{
    public interface IGarageRepository
    {
        Task InsertGarageAsync(Garage garage);
        Task<GarageDetail> GetGarageByIdAsync(Guid userId);
        Task<bool> UpdateDoorStatusAsync(Door door);
        Task AddHistoricalDoorStatusLogAsync(DoorsStatusHistory doorsStatusHistory);
        Task<Door> GetDoorByIPAddressAsync(string ipAddress);
    }
}
