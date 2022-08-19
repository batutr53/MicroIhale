using EventBusRabbitMQ;
using EventBusRabbitMQ.Producer;
using MicroIhale.Sourcing.Data;
using MicroIhale.Sourcing.Data.Interface;
using MicroIhale.Sourcing.Hubs;
using MicroIhale.Sourcing.Mapping;
using MicroIhale.Sourcing.Repositories;
using MicroIhale.Sourcing.Repositories.Interfaces;
using MicroIhale.Sourcing.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<SourcingDatabaseSettings>(configuration.GetSection(nameof(SourcingDatabaseSettings)));
builder.Services.AddSingleton<ISourcingDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SourcingDatabaseSettings>>().Value);
builder.Services.AddTransient<ISourcingContext, SourcingContext>();
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IBidRepository, BidRepository>();
builder.Services.AddAutoMapper(typeof(SourcingMapping));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
    var factory = new ConnectionFactory() { 
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
        retryCount= int.Parse(configuration["EventBus:RetryCount"]);
    }

    return new DefaultRabbitMQPersistentConnection(factory, retryCount, logger);
    

});

builder.Services.AddSingleton<EventBusRabbitMQProcuder>();
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("https://localhost:44300/");
}));
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapHub<AuctionHub>("/auctionhub");
app.MapControllers();

app.Run();
