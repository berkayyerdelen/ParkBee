using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ParkBee.Core.Domain.Users.Commands;
using System.Reflection;

namespace ParkBee.Core
{
    public static class CoreMiddlewareExtensions
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
        }
    }
}
