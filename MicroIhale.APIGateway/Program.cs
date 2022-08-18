using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddControllers();

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();


app.UseOcelot().Wait();
app.MapControllers();
app.Run();
