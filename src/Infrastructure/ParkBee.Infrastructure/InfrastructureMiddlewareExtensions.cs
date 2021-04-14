using Microsoft.Extensions.DependencyInjection;
using ParkBee.Application.Interface;
using ParkBee.Core.Interface;
using ParkBee.Domain.GarageAggregate;
using ParkBee.Domain.UserAggregate;
using ParkBee.Infrastructure.Repositories;
using ParkBee.Infrastructure.Repositories.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure
{
    public static class InfrastructureMiddlewareExtensions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGarageRepository, GarageRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
