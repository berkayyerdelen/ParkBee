using MediatR;
using ParkBee.Application.Interface;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Core.Domain.Garages.Commands
{
    public class RefreshGarageStatusCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public bool Status { get; set; }
    }
    public class RefreshGarageStatusCommandHandler : IRequestHandler<RefreshGarageStatusCommand>
    {
        private readonly IGarageRepository _garegeRepository;

        public RefreshGarageStatusCommandHandler(IGarageRepository garegeRepository)
        {
            _garegeRepository = garegeRepository;
        }

        public async Task<Unit> Handle(RefreshGarageStatusCommand request, CancellationToken cancellationToken)
        {
            var garage = await _garegeRepository.GetGarageByIdAsync(request.UserId);
            var door = garage.Doors.FirstOrDefault(x => x.IPAddress == request.IPAddress);
            var doorCurrentStatus = door.IsActive;
            door.UpdateStatus(request.Status);
            await _garegeRepository.UpdateDoorStatus(door);
            if (doorCurrentStatus != request.Status)
            {
                await _garegeRepository.AddHistoricalDoorStatusLog(
                    DoorsStatusHistory.CreateDoorsStatusHistory(door.Id, doorCurrentStatus, request.Status, DateTime.UtcNow));
            }
            return Unit.Value;
        }
    }
}
