using FluentValidation;
using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Validators;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using MeuEccomerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

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
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDataContext>()
            .AddDefaultTokenProviders();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["TokenConfiguration:Issuer"],
                    ValidAudience = configuration["TokenConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        return services;
    }
}
