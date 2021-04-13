using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ParkBee.Core.Domain.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
