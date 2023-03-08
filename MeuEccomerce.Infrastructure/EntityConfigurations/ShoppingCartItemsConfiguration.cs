using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.Infrastructure.EntityConfigurations
{
    public class ShoppingCartItemsConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItems", Data.ApplicationDataContext.DEFAULT_SCHEMA);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(10, 2);

            builder.Property(s => s.Quantity)
                .IsRequired()
                .HasColumnType("integer");
        }
    }
}
