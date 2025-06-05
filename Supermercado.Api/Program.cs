using Supermercado.Api.Infrastructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AgregarServiciosInfrastructura(builder.Configuration);
builder.Services.AddNHibernate(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.



app.MapControllers();

app.Run();
