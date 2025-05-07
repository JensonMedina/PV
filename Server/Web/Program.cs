using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Logging;
using Domain.Interfaces;
using Application.Services;
using Application.Common;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


#region Configuraciones
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

#endregion

#region Inyección de Servicios
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoggerApp, Logger>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INegocioService, NegocioService>();
builder.Services.AddScoped<IRubroService, RubroService>();
builder.Services.AddScoped<IPlanSaasService, PlanSaasService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IMedioPagoService, MedioPagoService>();
builder.Services.AddScoped<IPuestoService, PuestoService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ValidationFilter>();
#endregion



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
builder.Services.AddScoped<IMedioPagoRepository, MedioPagoRepository>();
#endregion




#region DbContext

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseMySql(builder.Configuration.GetConnectionString("JensonConnectionLocal"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("JensonConnectionLocal"))));
//builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
//{
//    var _logger = serviceProvider.GetRequiredService<ILoggerApp>();

//    options.UseMySql(
//            builder.Configuration.GetConnectionString("JensonConnectionLocal"),
//            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("JensonConnectionLocal"))
//        )
//        .EnableSensitiveDataLogging()
//        .LogTo(log => _logger.LogInfo("EFCore", log), LogLevel.Information); // Ahora sí, usando una instancia
//});
#endregion

#region IdentityCore
builder.Services.AddIdentity<Usuario, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
#endregion

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AuthenticationService:Issuer"],
        ValidAudience = builder.Configuration["AuthenticationService:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["AuthenticationService:Key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("JWT Authentication failed: " + context.Exception.Message);
            return Task.CompletedTask;
        }
    };
});
#endregion
#region  Autorizacion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DueñoPolicy", policy =>
        policy.RequireClaim("tipo_usuario", "Dueño"));
    options.AddPolicy("AdministradorPolicy", policy =>
        policy.RequireClaim("tipo_usuario", "Administrador"));
    options.AddPolicy("EmpleadoPolicy", policy =>
        policy.RequireClaim("tipo_usuario", "Empleado"));
});
#endregion
#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese su token JWT: "
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
#endregion
var app = builder.Build();


// Configuracion del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();