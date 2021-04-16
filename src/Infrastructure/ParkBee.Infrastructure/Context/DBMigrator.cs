using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Context
{
    public static class DBMigrator
    {
        public static IHost MigrateDbContext(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationContext>();
                if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }
                }             
            }
            return host;
        }
    }

}
