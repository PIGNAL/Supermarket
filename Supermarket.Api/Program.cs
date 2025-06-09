using Supermarket.Api.Infrastructure;
using Supermarket.Api.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEFCoreInfrastructureServices(builder.Configuration);
builder.Services.AddNHibernate(builder.Configuration); 
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.



app.MapControllers();

app.Run();
