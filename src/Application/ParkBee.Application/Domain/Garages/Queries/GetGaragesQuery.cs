using MediatR;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Core.Domain.Garages.Queries
{
    public class GetGaragesQuery : IRequest<Garage>
    {
        public Guid UserId { get; set; }
    }
    public class GetGaragesQueryHandler : IRequestHandler<GetGaragesQuery,Garage>
    {
        private IGarageRepository _garageRepository;
        public async Task<Garage> Handle(GetGaragesQuery request, CancellationToken cancellationToken)
        {
            return await _garageRepository.GetGaregeByIdAsync(request.UserId);
        }
    }
}
