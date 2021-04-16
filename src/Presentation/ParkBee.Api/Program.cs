using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ParkBee.Infrastructure.Context;

namespace ParkBee.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDbContext().SeedDatabase().Run(); 
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
