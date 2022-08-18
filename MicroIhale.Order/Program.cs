using EventBusRabbitMQ;
using EventBusRabbitMQ.Producer;
using MicroIhale.Order.Consumers;
using MicroIhale.Order.Extensions;
using MicroIhale.Order.Mapping;
using Microsoft.EntityFrameworkCore;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper(typeof(OrderMapping));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
    var factory = new ConnectionFactory()
    {
        HostName = configuration["EventBus:HostName"]
    };
    if (!string.IsNullOrWhiteSpace(configuration["EventBus:UserName"]))
    {
        factory.UserName = configuration["EventBus:UserName"];
    }
    if (!string.IsNullOrWhiteSpace(configuration["EventBus:Password"]))
    {
        factory.Password = configuration["EventBus:Password"];
    }

    var retryCount = 5;
    if (!string.IsNullOrWhiteSpace(configuration["EventBus:RetryCount"]))
    {
        retryCount = int.Parse(configuration["EventBus:RetryCount"]);
    }

    return new DefaultRabbitMQPersistentConnection(factory, retryCount, logger);


});

builder.Services.AddSingleton<EventBusOrderCreateConsumer>();
//builder.Services.AddSingleton<EventBusRabbitMQProcuder>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrderContext>();
   
       // db.Database.Migrate();
    
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();
app.UseRabbitListener();
app.Run();
