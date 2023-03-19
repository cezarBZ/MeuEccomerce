using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.Infrastructure.EntityConfigurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails", Data.ApplicationDataContext.DEFAULT_SCHEMA);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.OrderId)
                .IsRequired()
                .HasColumnType("integer");

            builder.HasOne<Product>()
                .WithMany()
                .IsRequired()
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_OrderDetails");

            builder.Property(s => s.Quantity)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(10, 2);
        }
    }
}