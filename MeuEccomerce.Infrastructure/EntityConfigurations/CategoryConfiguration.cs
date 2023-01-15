using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuEccomerce.Infrastructure.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category", Data.ApplicationDataContext.DEFAULT_SCHEMA);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();


        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.ImageUrl)
            .HasMaxLength(400);
    }
}
