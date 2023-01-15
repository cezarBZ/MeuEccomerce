using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using MeuEccomerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuEccomerce.API.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDataContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDataContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        return services;
    }
}
