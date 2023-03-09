

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.Infrastructure.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Address1)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Endereco");

            builder.Property(p => p.Address2)
                .HasMaxLength(100);

            builder.Property(p => p.ZipCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.State)
                .HasMaxLength(10);

            builder.Property(p => p.City)
                .HasMaxLength(50);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("varchar(25)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasAnnotation("RegularExpression", @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            builder.Property(p => p.TotalOrderPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.TotalOrderItems);

            builder.Property(p => p.OrderSent)
                .HasColumnType("datetime");

            builder.Property(p => p.OrderDelivered)
                .HasColumnType("datetime");
        }
    }
}
