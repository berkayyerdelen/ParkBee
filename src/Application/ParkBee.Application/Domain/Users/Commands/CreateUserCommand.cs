using MediatR;
using ParkBee.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkBee.Domain.GarageAggregate;
namespace ParkBee.Core.Domain.Users.Commands
{
    public class CreateUserCommand:IRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.InsertUserAsync(User.CreateCustomer(
                FullName.CreateFullName(request.FirstName,request.MiddleName,request.LastName),
                UserCredentials.CreateUserCredentials(request.UserName,request.Password),Role.CreateRole("Admin")));
            return Unit.Value;
        }
    }
}
