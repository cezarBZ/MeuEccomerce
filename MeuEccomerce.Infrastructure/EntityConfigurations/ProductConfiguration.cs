using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuEccomerce.Infrastructure.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", Data.ApplicationDataContext.DEFAULT_SCHEMA);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Property(p => p.Inventory)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(p => p.RegisterDate)
            .IsRequired();

        builder.HasOne<Category>()
           .WithMany()
           .IsRequired()
           .HasForeignKey(_ => _.CategoryId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Product_Category");
    }
}
