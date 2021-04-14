using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkBee.Application.Interface;
using ParkBee.Domain.GarageAggregate;
using ParkBee.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Context
{
    public static class Seeder
    {
        public static IHost MigrateDbContext(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationContext>();

                var JohnUserId = new Guid("9c90483c-3a44-47b2-a44c-ea62bf7f1558");
                var JaneUserId = new Guid("f2f150be-2933-4ded-b725-8fc09a933a00");

                if (!context.Set<User>().Any())
                {
                    context.Set<User>().Add(
                        User.CreateCustomerWithId(JohnUserId, FullName.CreateFullName("John", null, "Doe"),
                    UserCredentials.CreateUserCredentials("Johny", "Pa55w0rd"), Role.CreateRole("Admin")));

                    context.Set<User>().Add(
                        User.CreateCustomerWithId(JaneUserId, FullName.CreateFullName("Jane", null, "Doe"),
                    UserCredentials.CreateUserCredentials("Jane", "Password"), Role.CreateRole("Admin")));

                    context.Set<Garage>().Add(Garage.CreateGarage("Hank's Garage", "nl",
                     GarageDetail.CreateGarageDetail("Hank's Place", GeoLocation.CreateGeoLocation(50, 5),
                    Address.CreateAddress("Netherland", "Amsterdam", "Next st.", "1019"),
                             new List<Door>()
                             {
                                Door.CreateDoor(DoorType.Entry,"Entry Door 1","d99948a4-71b8-4c67-b1c5-516bd386e152",true),
                                Door.CreateDoor(DoorType.Exit,"Entry Exit","02ca2795-9f3c-4e07-ae10-cc60b62660f0",true),
                                Door.CreateDoor(DoorType.Entry,"Entry Door 2","44971013-6e13-41ac-840d-177e05df8899",false)
                              }), JohnUserId));

                    context.Set<Garage>().Add(
                        Garage.CreateGarage("Marc's Garage", "nl",
                        GarageDetail.CreateGarageDetail("Marc's Place", GeoLocation.CreateGeoLocation(45, 4),
                        Address.CreateAddress("Netherland", "Roterdam", "Previos st.", "3000"),
                             new List<Door>()
                             {
                                Door.CreateDoor(DoorType.Entry,"Entry Door 1","9248e2cb-6279-4a20-8976-0d5f2482cc21",true),
                                Door.CreateDoor(DoorType.Exit,"Entry Exit","818d2543-4a8a-4db9-89e8-128eabe12ca8",true),
                             }), JaneUserId));

                    context.SaveChanges();
                }
            }
            return host;
        }
    }
}
