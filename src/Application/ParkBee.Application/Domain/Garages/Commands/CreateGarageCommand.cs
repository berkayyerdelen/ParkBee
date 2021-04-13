using MediatR;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Core.Domain.Garages.Commands
{
    public class CreateGarageCommand : IRequest<Unit>
    {
        public string GarageName { get; set; }
        public string CountryCode { get; set; }
        public Guid CustomerId { get; set; }
    }
    public sealed class CreateGarageCommandHandler : IRequestHandler<CreateGarageCommand, Unit>
    {
        private readonly IGarageRepository _garegeRepository;

        public CreateGarageCommandHandler(IGarageRepository garegeRepository)
        {
            _garegeRepository = garegeRepository;
        }

        public async Task<Unit> Handle(CreateGarageCommand request, CancellationToken cancellationToken)
        {
            await _garegeRepository.InsertGarageAsync(Garage.CreateGarage(request.GarageName, request.CountryCode, null, request.CustomerId));
            return Unit.Value;
        }
    }
}
