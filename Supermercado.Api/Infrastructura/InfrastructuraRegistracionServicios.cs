using Microsoft.EntityFrameworkCore;
using Supermercado.Data;
using Supermercado.Data.Repositorios;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Api.Infrastructura
{
    public static class InfrastructuraRegistracionServicios
    {
        public static IServiceCollection AgregarServiciosInfrastructura(this IServiceCollection servicios, IConfiguration configuracion)
        {
            // Configuración de la cadena de conexión a la base de datos
            servicios.AddDbContext<SupermercadoDbContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("DefaultConnection"));
            });
            // Configuración de los repositorios
            servicios.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            servicios.AddScoped<IVentaRepositorio, VentaRepositorio>();
            return servicios;
        }
    }
}
