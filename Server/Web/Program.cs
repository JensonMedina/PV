using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoggerApp, Logger>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


#region Inyección de repositorios
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
