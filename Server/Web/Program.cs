using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Application.Mappings;
using AutoMapper;

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

#region Agregamos el servicio del DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(

        builder.Configuration.GetConnectionString("BrunoConnectionLocal"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BrunoConnectionLocal"))
    )
);
#endregion

var app = builder.Build();
//---------------------------------------------------------------------------
// si no tira excepcion es porque la configuracion de automapper es correcta
var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();
//-----------------------------------------------------------------------------

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
