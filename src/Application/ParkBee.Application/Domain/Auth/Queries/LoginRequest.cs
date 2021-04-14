using MediatR;
using ParkBee.Core.Common.DTO;
using ParkBee.Core.Interface;
using ParkBee.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Core.Domain.Auth.Queries
{
    public class LoginRequest : IRequest<TokenResponseModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public sealed class LoginRequestHandler : IRequestHandler<LoginRequest, TokenResponseModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        public LoginRequestHandler(IAuthenticationService authenticationService, IUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }
        public async Task<TokenResponseModel> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserName, request.Password);
            var tokenModel = _authenticationService.GenerateJwtSecurityToken(new() { UserName = user.UserCredentials.UserName, Role = user.Role.Roles });
            return tokenModel;
        }
    }
}
