using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Core.Domain.Garages.Commands;
using ParkBee.Core.Domain.Garages.Queries;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Threading.Tasks;

namespace ParkBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GaragesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GaragesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]
        [ProducesDefaultResponseType(typeof(GarageDetail))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGarageDetailsAsync(Guid userId)
        {
            return Ok(await _mediator.Send(new GetGaragesQuery(userId)));
        }
        [HttpPost("RefreshDoorStatus")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshDoorStatusAsync(RefreshGarageStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
