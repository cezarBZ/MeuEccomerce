using Autofac;
using FluentValidation;
using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Infrastructure.AutoFacModules;
using MeuEccomerce.API.Validators;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using MeuEccomerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
        
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<CategoryValidator>();
        services.AddScoped<IValidator<CreateCategoryCommand>, CategoryValidator>();
        services.AddTransient<ProductValidator>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IValidator<AddProductCommand>, ProductValidator>();

        return services;
    }
}
