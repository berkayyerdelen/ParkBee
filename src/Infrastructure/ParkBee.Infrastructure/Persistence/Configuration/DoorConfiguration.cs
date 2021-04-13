using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Domain.GarageAggregate;

namespace ParkBee.Infrastructure.Persistence.Configuration
{
    public class DoorConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder.ToTable("Doors", "parkbee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DoorType);
            builder.Property(x => x.IPAddress);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Description);
        }
    }
}
