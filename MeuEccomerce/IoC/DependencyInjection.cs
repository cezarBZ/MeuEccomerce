using MediatR;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Application.Services;
using MeuEccomerce.Infrastructure.Data;
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
        services.AddScoped(sp => ShoppingCartService.Get(sp));
        services.AddAutoMapper(typeof(AutoMapperProfile));
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
        services.AddSession(options =>
        {
            options.Cookie.Name = "MySessionCookie";
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.IsEssential = true;
        });
        services.AddMemoryCache();
        services.AddMvc();
       
        return services;
    }
}
