using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Domain.UserAggregate;

namespace ParkBee.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "parkbee");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.FullName, cx =>
             {
                 cx.Property(k => k.FirstName).HasColumnName("FirstName");
                 cx.Property(k => k.MiddleName).HasColumnName("MiddleName");
                 cx.Property(k => k.LastName).HasColumnName("LastName");
             });
            builder.OwnsOne(x => x.UserCredentials, cx =>
            {
                cx.Property(k => k.UserName).HasColumnName("UserName");
                cx.Property(k => k.Password).HasColumnName("Password");
            });
            builder.OwnsOne(x => x.Role, cx =>
            {
                cx.Property(k => k.Roles).HasColumnName("Role");        
            });
        }
    }
}
