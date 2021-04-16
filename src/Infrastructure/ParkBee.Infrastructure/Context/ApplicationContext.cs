using Microsoft.EntityFrameworkCore;
using ParkBee.Application.Interface;
using ParkBee.Domain.GarageAggregate;
using ParkBee.Domain.UserAggregate;
using ParkBee.Infrastructure.Persistence.Configuration;

namespace ParkBee.Infrastructure
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<GarageDetail> GarageDetails { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DoorsStatusHistory> DoorsStatusHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoorConfiguration).Assembly);

        }
    }
}
