using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Domain.GarageAggregate;

namespace ParkBee.Infrastructure.Persistence.Configuration
{
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.ToTable("Garages", "parkbee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GarageName);
            builder.Property(x => x.CountryCode);
            builder.HasOne(x => x.GarageDetail).WithOne().HasForeignKey<GarageDetail>(p => p.GarageId);

        }
    }
}
