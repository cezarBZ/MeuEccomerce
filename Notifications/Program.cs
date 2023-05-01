using Notifications.Infrastructure;
using SendGrid.Extensions.DependencyInjection;
using Notifications.Subscribers;
using SendGrid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddScoped<INotificationService, EmailService>();
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = "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";
});

builder.Services.AddHostedService<OrderStatusChangedSubscriber>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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