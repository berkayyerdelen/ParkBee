using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Domain.GarageAggregate;

namespace ParkBee.Infrastructure.Persistence.Configuration
{
    public class GarageDetailConfiguration : IEntityTypeConfiguration<GarageDetail>
    {
        public void Configure(EntityTypeBuilder<GarageDetail> builder)
        {
            builder.ToTable("GarageDetails", "parkbee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GarageName);
            builder.OwnsOne(x => x.GeoLocation, cx =>
            {
                cx.Property(k => k.Latitude).HasColumnName("Latitude");
                cx.Property(k => k.Longitude).HasColumnName("Longitude");
            });
            builder.OwnsOne(x => x.Address, cx =>
            {
                cx.Property(k => k.Country).HasColumnName("Country");
                cx.Property(k => k.City).HasColumnName("City");
                cx.Property(k => k.PostalCode).HasColumnName("PostalCode");
                cx.Property(k => k.StreetAddress).HasColumnName("StreetAddress");
            });
            builder.HasMany(x => x.Doors).WithOne();
        }
    }
}
