using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Domain.GarageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Persistence.Configuration
{
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.ToTable("Garage", "parkbee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GarageName);
            builder.Property(x => x.CountryCode);
            builder.HasOne(x => x.GarageDetail).WithOne();

        }
    }
}
