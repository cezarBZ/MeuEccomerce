using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Infrastructure.AutoFacModules;
using MeuEccomerce.API.IoC;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/meueccomerceLogs.txt", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Debug()
            .Enrich.WithEnvironmentName()
            .Enrich.WithProcessName()
            .Enrich.FromLogContext()
            .CreateBootstrapLogger();
        try
        {
            Log.Information("Starting application");

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Console());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(mapper);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(_ =>
            {
                _.RegisterModule(new MediatorModule());
                _.RegisterModule(new ApplicationModule(builder.Configuration));
            });
            var app = builder.Build();
            app.UseSerilogRequestLogging();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally 
        { 
            Log.CloseAndFlush();
        }
        
    }
}