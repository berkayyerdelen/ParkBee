using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Core.Domain.Users.Commands;
using ParkBee.Core.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand command)
            => Ok(await _mediator.Send(command));
       
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
            => Ok(await _mediator.Send(new GetUsersQuery()));

    }
}
