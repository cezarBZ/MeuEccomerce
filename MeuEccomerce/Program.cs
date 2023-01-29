using Autofac;
using Autofac.Core;
using AutoMapper;
using MeuEccomerce.API.Application.Mappings;
using MeuEccomerce.API.Infrastructure.AutoFacModules;
using MeuEccomerce.API.IoC;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DomainToDTOMappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
