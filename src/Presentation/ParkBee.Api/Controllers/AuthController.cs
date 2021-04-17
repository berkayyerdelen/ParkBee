using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Core.Common.Dto;
using ParkBee.Core.Domain.Auth.Queries;
using System.Threading.Tasks;

namespace ParkBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(TokenResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
