using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using MeuEccomerce.Domain.AggregatesModel.UserAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuEccomerce.Infrastructure.Data;

public class ApplicationDataContext : IdentityDbContext<User>, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "MYE";
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
       
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext)
            .Assembly);
        builder.HasDefaultSchema(DEFAULT_SCHEMA);
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderDetailsConfiguration());
        builder.ApplyConfiguration(new ShoppingCartItemsConfiguration());

    }

}
public class ApplicationDataContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
{
    public ApplicationDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>()
            .UseSqlServer("Server=NTB-2KY74W2;Database=MeuEccomerce;Trusted_Connection=True;");

        return new ApplicationDataContext(optionsBuilder.Options);
    }
}
