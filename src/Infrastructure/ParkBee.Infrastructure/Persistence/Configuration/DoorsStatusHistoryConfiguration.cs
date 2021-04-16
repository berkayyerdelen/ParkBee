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
    public class DoorsStatusHistoryConfiguration : IEntityTypeConfiguration<DoorsStatusHistory>
    {
        public void Configure(EntityTypeBuilder<DoorsStatusHistory> builder)
        {
            builder.ToTable("DoorsStatusHistory", "parkbee");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DoorId);
            builder.Property(x => x.OldStatus);
            builder.Property(x => x.NewStatus);
            builder.Property(x => x.CreatedDate);
        }
    }
}
