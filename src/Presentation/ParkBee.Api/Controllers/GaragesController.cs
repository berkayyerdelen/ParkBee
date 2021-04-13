using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Core.Domain.Garages.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GaragesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{garageId}")]
        public async Task<IActionResult> GetGarageDetailsAsync(Guid garageId)
        {
            return Ok(await _mediator.Send(new GetGaragesQuery(garageId)));
        }
    }
}
