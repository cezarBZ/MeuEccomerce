using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuEccomerce.Domain.AggregatesModel.UserAggregate;

namespace MeuEccomerce.Infrastructure.EntityConfigurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddress", Data.ApplicationDataContext.DEFAULT_SCHEMA);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.UserId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(p => p.StreetName)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.City)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.PostalCode)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.Country)
            .IsRequired()
            .HasMaxLength(100);
        }   

    }
}
