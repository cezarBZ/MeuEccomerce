using Autofac;
using MediatR;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Infrastructure.AutoFacModules;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using MeuEccomerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuEccomerce.API.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDataContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDataContext).Assembly.FullName)));
        
        var container = new ContainerBuilder();
        container.RegisterModule(new MediatorModule());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        container.RegisterModule(new ApplicationModule("Server=NTB-2KY74W2;Database=MeuEccomerce;Trusted_Connection=True;"));
        //services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        return services;
    }
}
