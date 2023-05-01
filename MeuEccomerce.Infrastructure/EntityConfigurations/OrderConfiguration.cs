using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.UserAggregate;

namespace MeuEccomerce.Infrastructure.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", Data.ApplicationDataContext.DEFAULT_SCHEMA);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
              .Property<int>("_statusId")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("StatusId")
              .IsRequired();

            builder.HasOne<User>()
           .WithMany()
           .IsRequired()
           .HasForeignKey(_ => _.CustomerId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_User_Order");

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
