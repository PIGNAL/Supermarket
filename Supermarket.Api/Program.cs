using Supermarket.Api.Infrastructure;
using Supermarket.Api.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers();

builder.Services.AddEFCoreInfrastructureServices(builder.Configuration);
builder.Services.AddNHibernate(builder.Configuration); 
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddMediatRRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.



app.MapControllers();

app.Run();
