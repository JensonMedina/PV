using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Application.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args); 
//----------------------------------------------------------------------------------------------------------------------------------------------
// AutoMapper, la funcion ADDautoMapper se encarga de escanear el assembly y registrar todos los perfiles que encuentre en (DomainToDtoProfile 
builder.Services.AddAutoMapper(typeof(DomainToDtoProfile).Assembly);
//----------------------------------------------------------------------------------------------------------------------------------------------

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoggerApp, Logger>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#region Inyecciï¿½n de repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICompraDetalleRepository, CompraDetalleRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<IComprobanteRepository, ComprobanteRepository>();
builder.Services.AddScoped<IHistoricoPrecioRepository, HistoricoPrecioRepository>();
builder.Services.AddScoped<IHistoricoStockRepository, HistoricoStockRepository>();
builder.Services.AddScoped<INegocioRepository, NegocioRepository>();
builder.Services.AddScoped<IPlanSaasRepository, PlanSaasRepository>();
builder.Services.AddScoped<IProductoNegocioRepository, ProductoNegocioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IPuestoRepository, PuestoRepository>();
builder.Services.AddScoped<IRubroRepository, RubroRepository>();
builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
builder.Services.AddScoped<IUsuarioPuestoRepository, UsuarioPuestoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVentaDetalleRepository, VentaDetalleRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
#endregion


#region Agregamos el servicio del DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MateoConnectionLocal"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MateoConnectionLocal"))
    )
);
#endregion

var app = builder.Build();
//---------------------------------------------------------------------------
// si no tira excepcion es porque la configuracion de automapper es correcta
var mapper = app.Services.GetRequiredService<IMapper>();
try
{
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}
catch (AutoMapperConfigurationException ex)
{
    // Esto te mostrará exactamente qué CreateMap está fallando
    Console.WriteLine("AutoMapper ERROR:");
    Console.WriteLine(ex.Message);
    throw;
}//-----------------------------------------------------------------------------

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
